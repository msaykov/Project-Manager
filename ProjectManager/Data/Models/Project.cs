using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ProjectManager.Data.DataConstants;

namespace ProjectManager.Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(ProjectNameMaxLength)]
        public string Name { get; set; }

        public int TypeId { get; set; }

        public Type Type { get; set; }

        public int TownId { get; private set; }

        public Town Town { get; set; }

        public int EmployeeId { get; private set; }

        public Employee Employee { get; set; }

        public string Description { get; set; }

        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }
        
        public Status Status { get; set; }

        public IEnumerable<ProjectsMaterial> Materials { get; private set; } = new List<ProjectsMaterial>();

        //public IEnumerable<Note> Notes { get; private set; } = new List<Note>();

    }
}
