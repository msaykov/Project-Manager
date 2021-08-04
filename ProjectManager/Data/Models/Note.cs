namespace ProjectManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Note
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
