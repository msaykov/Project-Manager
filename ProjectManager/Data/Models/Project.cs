namespace ProjectManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ProjectManager.Data.DataConstants.Project;

    public class Project
    {
        public Project()
        {
            this.Materials = new List<Material>();
            this.StartDate = DateTime.Now;
        }
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(ProjectNameMaxLength)]
        public string Name { get; set; }

        public int ProjectTypeId { get; private set; }

        public ProjectType ProjectType { get; set; }

        public int TownId { get; private set; }

        public Town Town { get; set; }

        public int OwnerId { get; private set; }

        public Owner Owner { get; set; }

        //public string EmployeeId { get; private set; }

        //public Employee Employee { get; set; }

        [Required]
        [MaxLength(ProjectDescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }
        
        public Status Status { get; set; }

        public ICollection<Material> Materials { get; set; }

        //public IEnumerable<Note> Notes { get; private set; } = new List<Note>();

    }
}
