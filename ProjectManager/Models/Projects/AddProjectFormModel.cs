using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models.Projects
{
    public class AddProjectFormModel
    {
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Display(Name = "Project Type")]
        public string Type { get; set; }

        public string Town { get; set; }

        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        [Display(Name = "Project Status")]
        public int StatusId { get; set; }

        public IEnumerable<ProjectStatusViewModel> Statuses { get; set; }
    }
        //public string Employee { get; set; }
}
