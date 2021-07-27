
namespace ProjectManager.Models.Projects
{
    using ProjectManager.Data.Models;
    using System.Collections.Generic;

    public class ProjectInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Town { get; set; }

        public string Owner { get; set; }

        public string EndDate { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public IEnumerable<Material> Materials { get; set; } = new List<Material>();
    }
}
