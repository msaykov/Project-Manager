
namespace ProjectManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ProjectManager.Data.DataConstants.Material;

    public class Material
    {
        public Material()
        {
            this.Projects = new List<Project>();
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(MaterialNameMaxLength)]
        public string Name { get;  set; }

        public int SapNumber { get;  set; }

        public decimal Price { get;  set; }

        public int MaterialTypeId { get; set; }

        public MaterialType MaterialType { get;  set; }

        public int Quantity { get;  set; }

        public ICollection<Project> Projects { get;  set; }
    }
}
