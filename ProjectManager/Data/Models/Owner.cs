
namespace ProjectManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Owner
    {
        public Owner()
        {
            this.Projects = new List<Project>();
        }

        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        //[Required]
        public string PhoneNumber { get; set; }


        public string UserId { get; set; }

        public IEnumerable<Project> Projects { get; set; }

    }
}
