namespace ProjectManager.Services.Projects
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class ProjectServiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Project Name")]
        [Required]
        [StringLength(ProjectNameMaxLength, MinimumLength = ProjectNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Name { get; set; }

        [Display(Name = "Project Type")]
        [Required]
        [StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Type { get; set; }

        public string Owner { get; set; }

        [Required]
        [StringLength(TownNameMaxLength, MinimumLength = TownNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Town { get; set; }

        [Display(Name = "End Date")]
        [Required]
        //[DataType(DataType.Date)]
        public string EndDate { get; set; }

        public string Status { get; set; }

        public bool IsOwner { get; set; }
    }
}
