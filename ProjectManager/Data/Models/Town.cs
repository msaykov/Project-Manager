using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ProjectManager.Data.DataConstants;

namespace ProjectManager.Data.Models
{
    public class Town
    {
        public int Id { get; private set; }

        [Required]
        [MaxLength(TownNameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Project> Projects { get; private set; } = new List<Project>();
    }
}