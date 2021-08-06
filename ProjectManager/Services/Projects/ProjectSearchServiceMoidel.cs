namespace ProjectManager.Services.Projects
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProjectSearchServiceMoidel
    {
        public IEnumerable<ProjectServiceModel> Projects { get; set; }

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
