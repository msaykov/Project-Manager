namespace ProjectManager.Services.Materials
{
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MaterialService : IMaterialService
    {
        private readonly ProjectManagerDbContext data;

        public MaterialService(ProjectManagerDbContext data)
            => this.data = data;

        public ICollection<MaterialServiceModel> All(int projectId)
            => this.data
                .Materials
                .Where(m => m.Projects.Any(p => p.Id == projectId))
                .Select(m => new MaterialServiceModel
                {
                    Name = m.Name,
                    Type = m.MaterialType.Name,
                    SapNumber = m.SapNumber,
                    Price = m.Price,
                    Quantity = m.Quantity
                })
                .ToList();


        public void Create(int projectId, string name, string type, int sapNumber, decimal price, int quantity)
        {
            var currentProject = GetProjectById(projectId);
            var currentType = GetMaterialType(type);
            var materialType = currentType == null ? new MaterialType { Name = type } : currentType;

            var materialEntity = new Material
            {
                Name = name,
                MaterialType = materialType,
                SapNumber = sapNumber,
                Price = price,
                Quantity = quantity,
            };

            currentProject.Materials.Add(materialEntity);
            this.data.SaveChanges();
        }

        public MaterialType GetMaterialType(string name)
            => this.data
                   .MaterialTypes
                   .FirstOrDefault(mt => mt.Name == name);

        public Project GetProjectById(int id)
             => this.data
                .Projects
                .FirstOrDefault(p => p.Id == id);
    }


}

