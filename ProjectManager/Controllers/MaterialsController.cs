namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using ProjectManager.Models.Materials;
    using ProjectManager.Services.Materials;
    using System.Linq;

    public class MaterialsController : Controller
    {
        //private readonly ProjectManagerDbContext data;
        private readonly IMaterialService material;

        public MaterialsController(IMaterialService material)
        {
            this.material = material;
            //this.data = data;
        }

        [Authorize]
        public IActionResult Add()
        {
            var types = material.GetMaterialTypes();
            var materials = material.GetMaterialNames();
            return View(new AddMaterialServiceModel 
            {
                Materials = materials,
                Types = types,
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddMaterialServiceModel model, int id) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }



            this.material.Create(id, model.MaterialId, model.MaterialTypeId, model.Quantity);

            return RedirectToAction(nameof(All), new { id = id });
        }

        public IActionResult All(int id)
        {

            var allMaterials = material.All(id);

            return View(new AllMaterialsServiceModel 
            {
                ProjectId = id,
                Materials = allMaterials,
            });
        }

        
    }
}
