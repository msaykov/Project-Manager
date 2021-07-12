using System.Collections.Generic;

namespace ProjectManager.Data.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Project> Projects { get; private set; } = new List<Project>();

    }
}
