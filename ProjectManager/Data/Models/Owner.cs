
namespace ProjectManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ProjectManager.Data.DataConstants;

    public class Owner
    {
        public Owner()
        {
            this.Projects = new List<Project>();
        }

        public int Id { get; private set; }

        [Required]
        [MaxLength(OwnerNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }

        public ICollection<Project> Projects { get; set; }

    }
}
