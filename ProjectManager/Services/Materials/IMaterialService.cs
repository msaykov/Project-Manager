namespace ProjectManager.Services.Materials
{
    using ProjectManager.Data.Models;
    using System.Collections.Generic;

    public interface IMaterialService
    {
        void Create(int projectId, string name, string type, int sapNumber, decimal price, int quantity);

        ICollection<MaterialServiceModel> All(int id);

        MaterialType GetMaterialType(string name);

        Project GetProjectById(int id);

    }
}
