using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ProjectManager.Data.DataConstants;

namespace ProjectManager.Data.Models
{

    public class Material
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(MaterialNameMaxLength)]
        public string Name { get; private set; }

        public int SapNumber { get; private set; }

        public double Price { get; private set; }

        public int TypeId { get; set; }

        public Type Type { get; private set; }

        public int Quantity { get; private set; }

        public IEnumerable<ProjectsMaterial> Projects { get; private set; } = new List<ProjectsMaterial>();
    }
}
