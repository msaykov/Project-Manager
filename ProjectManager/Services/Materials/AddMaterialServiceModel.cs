namespace ProjectManager.Services.Materials
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddMaterialServiceModel
    {
        public int MaterialTypeId { get; set; }

        public ICollection<MaterialTypesServiceModel> Types { get; set; }

        public int MaterialId { get; set; }

        public ICollection<MaterialNamesServiceModel> Materials { get; set; }

        public int Quantity { get; set; }
    }
}
