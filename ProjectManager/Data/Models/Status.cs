namespace ProjectManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ProjectManager.Data.DataConstants;

    public class Status
    {
        public Status()
        {
            this.Projects = new List<Project>();
        }

        public int Id { get; private set; }

        [Required]
        [MaxLength(StatusNameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Project> Projects { get; private set; }

    }
}
