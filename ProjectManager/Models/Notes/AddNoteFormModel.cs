namespace ProjectManager.Models.Notes
{
    using ProjectManager.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddNoteFormModel
    {
        [Required]
        public string Content { get; set; }

        public ICollection<string> Statuses { get; set; }
    }
}
