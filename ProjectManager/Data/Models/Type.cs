using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ProjectManager.Data.DataConstants;

namespace ProjectManager.Data.Models
{
    public class Type
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Project> Projects { get; private set; } = new List<Project>();

        public IEnumerable<Material> Materials { get; private set; } = new List<Material>();
    }
}
