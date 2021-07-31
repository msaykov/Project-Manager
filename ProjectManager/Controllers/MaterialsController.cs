namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using ProjectManager.Models.Materials;
    using System.Linq;

    public class MaterialsController : Controller
    {
        private readonly ProjectManagerDbContext data;

        public MaterialsController(ProjectManagerDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Add() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddMaterialFormModel material, int id) 
        {
            var currentProject = GetProjectById(id);

            if (!ModelState.IsValid)
            {
                return View(material);
            }

            var currentType = this.data
                .MaterialTypes
                .FirstOrDefault(t => t.Name == material.Type);
            var materialType = currentType == null ? new MaterialType { Name = material.Type } : currentType;

            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userName = this.User.FindFirst(ClaimTypes.Email).Value;
            //var userPhone = this.User.FindFirst(ClaimTypes.Email).Value;

           
            var materialEntity = new Material
            {
                Name = material.Name,
                MaterialType = materialType,
                SapNumber = material.SapNumber,
                Price = material.Price,
                Quantity = material.Quantity,
            };

            currentProject.Materials.Add(materialEntity);
            this.data.SaveChanges();


            return RedirectToAction(nameof(All), new { id = id});
            //return RedirectToAction("Details", "Projects", new { id = id });
        }

        public IActionResult All(int id)
        {
            
            var allMaterials = this.data
                .Materials
                .Where(m => m.Projects.Any(p => p.Id == id))
                .Select(m => new MaterialInfoViewModel
                {
                    Name = m.Name,
                    Type = m.MaterialType.Name,
                    SapNumber = m.SapNumber,
                    Price = m.Price,
                    Quantity = m.Quantity
                })
                .ToList();

            return View(new ListMaterialViewModel 
            {
                ProjectId = id,
                Materials = allMaterials,
            });
        }

        private Project GetProjectById(int id)
            => this.data
            .Projects
            .FirstOrDefault(p => p.Id == id);
    }
}
