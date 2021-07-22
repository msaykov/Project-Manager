using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Data.Models
{
    public class Owner
    {
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

       // [Required]
        public string PhoneNumber { get; set; }


        public string UserId { get; set; }

        public IEnumerable<Project> Projects { get; set; } = new List<Project>();

    }
}
