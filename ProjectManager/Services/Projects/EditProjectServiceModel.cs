using ProjectManager.Models.Projects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Services.Projects
{
    
    public class EditProjectServiceModel : ProjectServiceModel
    {

        public string Description { get; set; }

        [Display(Name = "Project Status")]
        [Required]
        public int StatusId { get; set; }

        public IEnumerable<StatusesServiceModel> Statuses { get; set; }
    }
}
