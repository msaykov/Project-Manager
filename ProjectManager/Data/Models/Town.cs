using System.Collections.Generic;

namespace ProjectManager.Data.Models
{
    public class Town
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public IEnumerable<Project> Projects { get; private set; } = new List<Project>();
    }
}