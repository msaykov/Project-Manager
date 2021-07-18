using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models.Projects
{
    public class ProjectsSearchViewModel
    {
        public IEnumerable<ListProjectViewModel> Projects { get; set; }

        [Display(Name = "Search by Town name:")]
        public string TownName { get; set; }

        [Display(Name = "Search by Status:")]
        public string Status { get; set; }

        public IEnumerable<string> Statuses { get; set; }

        [Display(Name = "Search by Type:")]
        public string Type { get; set; }

        public IEnumerable<string> Types { get; set; }
    }
}
