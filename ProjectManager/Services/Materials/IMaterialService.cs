namespace ProjectManager.Services.Materials
{
    using ProjectManager.Data.Models;
    using System.Collections.Generic;

    public interface IMaterialService
    {
        //void Create(int projectId, string name, string type, int sapNumber, decimal price, int quantity);

        void Add(int projectId, int MaterialId, /*int MaterialTypeId,*/ int quantity);

        ICollection<MaterialServiceModel> All(int id);

        ICollection<MaterialTypesServiceModel> GetMaterialTypes();

        //ICollection<MaterialNamesServiceModel> GetMaterialNames(int typeId);
        ICollection<MaterialNamesServiceModel> GetMaterialNames();

        MaterialType GetMaterialType(int id);

        Project GetProjectById(int id);

    }
}
