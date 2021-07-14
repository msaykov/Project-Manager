﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models.Projects
{
    using static Data.DataConstants;
    public class AddProjectFormModel
    {
        [Display(Name = "Project Name")]
        [Required]
        [StringLength(ProjectNameMaxLength, MinimumLength = ProjectNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Name { get; set; }

        [Display(Name = "Project Type")]
        [Required]
        [StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Type { get; set; }

        [Display(Name = "Employee Name")]
        [Required]
        [StringLength(EmployeeNameMaxLength, MinimumLength = EmployeeNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Employee { get; set; }

        [Required]
        [StringLength(TownNameMaxLength, MinimumLength = TownNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Town { get; set; }

        [Display(Name = "End Date")]
        [Required]
        //[RegularExpression(DateRegEx)]
        public string EndDate { get; set; }

        [Display(Name = "Project Status")]
        [Required]
        public int StatusId { get; set; }

        public IEnumerable<ProjectStatusViewModel> Statuses { get; set; }
    }
    //public string Employee { get; set; }
}
