namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using ProjectManager.Models.Materials;
    using System.Collections.Generic;
    using System.Linq;

    public class MaterialsController : Controller
    {
        private readonly ProjectManagerDbContext data;

        public MaterialsController(ProjectManagerDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Add(int id) => View();

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
                .Types
                .FirstOrDefault(t => t.Name == material.Type);
            var materialType = currentType == null ? new ProjectType { Name = material.Type } : currentType;

            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userName = this.User.FindFirst(ClaimTypes.Email).Value;
            //var userPhone = this.User.FindFirst(ClaimTypes.Email).Value;

           
            var materialEntity = new Material
            {
                Name = material.Name,
                Type = materialType,
                SapNumber = material.SapNumber,
                Price = material.Price,
                Quantity = material.Quantity,
            };
            this.data.Materials.Add(materialEntity);
            this.data.SaveChanges();

            var currentMaterial = this.data
                .Materials
                .FirstOrDefault(m => m.SapNumber == materialEntity.SapNumber);

            var projectMaterialEntity = new ProjectMaterials
            {
                Material = materialEntity,
                Project = currentProject,
            };

            currentProject.Materials.Append(projectMaterialEntity);
            
            this.data.SaveChanges();





            



            //this.data.SaveChanges();

            return RedirectToAction(nameof(All), new { id = id});
        }

        public IActionResult All(int id)
        {
            var currrentProject = GetProjectById(id);
            var materials = currrentProject.Materials.ToList();

            var allMaterials = materials
                .Select(m => new MaterialInfoViewModel
                {
                    Name = m.Material.Name,
                    Type = m.Material.Type.Name,
                    SapNumber = m.Material.SapNumber,
                    Price = m.Material.Price,
                    Quantity = m.Material.Quantity
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
