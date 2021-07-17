using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models.Projects
{
    using static Data.DataConstants;

    public class ListProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Employee { get; set; }

        public string Town { get; set; }

        public string EndDate { get; set; }

        public string Status { get; set; }
    }
}
