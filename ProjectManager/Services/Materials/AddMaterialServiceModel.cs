namespace ProjectManager.Services.Materials
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddMaterialServiceModel
    {
        //[Display(Name = "Material Type:")]
        //public int MaterialTypeId { get; set; }

        //public ICollection<MaterialTypesServiceModel> Types { get; set; }

        [Display(Name = "Material Name:")]
        public int MaterialId { get; set; }

        public ICollection<MaterialNamesServiceModel> Materials { get; set; }

        public int Quantity { get; set; }
    }
}
