namespace ProjectManager.Models.Materials
{
    using ProjectManager.Services.Materials;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class AddMaterialFormModel
    {
        //[Display(Name = "Material Name")]
        //[Required]
        //[StringLength(MaterialNameMaxLength, MinimumLength = MaterialNameMinLength, ErrorMessage = NamesErrorMsg)]
        //public string Name { get; set; }

        //[Display(Name = "Material Type")]
        //[Required]
        //[StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength, ErrorMessage = NamesErrorMsg)]
        //public string Type { get; set; }

        //[Display(Name = "SAP Number")]
        //[Required]
        //public int SapNumber { get; set; }

        //public decimal Price { get; set; }

        //public int Quantity { get; set; }

        public int MaterialTypeId { get; set; }

        public ICollection<MaterialTypesServiceModel> Types { get; set; }

        public int MaterialId { get; set; }

        public ICollection<MaterialNamesServiceModel> Materials { get; set; }

        public int Quantity { get; set; }

    }
}
