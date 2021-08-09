namespace ProjectManager.Services.Materials
{
    using System.Collections.Generic;

    public class AllMaterialsServiceModel
    {
        public int ProjectId { get; set; }

        public ICollection<MaterialServiceModel> Materials { get; set; }
    }
}
