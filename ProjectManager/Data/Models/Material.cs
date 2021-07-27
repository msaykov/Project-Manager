
namespace ProjectManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ProjectManager.Data.DataConstants.Material;

    public class Material
    {
        public Material()
        {
            this.Projects = new List<ProjectMaterials>();
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(MaterialNameMaxLength)]
        public string Name { get;  set; }

        public int SapNumber { get;  set; }

        public double Price { get;  set; }

        public int TypeId { get; set; }

        public ProjectType Type { get;  set; }

        public int Quantity { get;  set; }

        public IEnumerable<ProjectMaterials> Projects { get;  set; }
    }
}
