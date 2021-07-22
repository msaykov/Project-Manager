using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Data.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Project> Projects { get; private set; } = new List<Project>();

    }
}
