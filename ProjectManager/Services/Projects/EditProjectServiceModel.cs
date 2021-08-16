namespace ProjectManager.Services.Projects
{
    using ProjectManager.Models.Projects;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class EditProjectServiceModel : ProjectServiceModel
    {
        [Required]
        [StringLength(ProjectDescriptionMaxLength, MinimumLength = ProjectDescriptionMinLength, ErrorMessage = NamesErrorMsg)]
        public string Description { get; set; }

        [Display(Name = "Project Status")]
        [Required]
        public int StatusId { get; set; }

        public ICollection<StatusesServiceModel> Statuses { get; set; }
    }
}
