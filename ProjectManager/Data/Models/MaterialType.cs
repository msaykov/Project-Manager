namespace ProjectManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ProjectManager.Data.DataConstants;

    public class MaterialType
    {
        public MaterialType()
        {
             this.Materials = new List<Material>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Material> Materials { get; private set; }

    }
}
