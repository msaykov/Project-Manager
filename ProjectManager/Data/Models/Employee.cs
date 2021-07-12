using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ProjectManager.Data.DataConstants;

namespace ProjectManager.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(EmployeeNameMaxLength)]
        public string Name { get; set; }

        //[Required]
        //public string Company { get; set; }


        //public string Email { get; set; }


        //public string Phone { get; set; }


        //public bool IsSubcontractor  { get; private set; }


        public IEnumerable<Project> Projects { get; private set; } = new List<Project>();
    }
}
