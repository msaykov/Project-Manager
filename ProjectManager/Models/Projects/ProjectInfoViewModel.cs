
namespace ProjectManager.Models.Projects
{
    using ProjectManager.Data.Models;
    using System.Collections.Generic;

    public class ProjectInfoViewModel : ListProjectViewModel
    {
        public ProjectInfoViewModel()
        {
            this.Materials = new List<Material>();
            this.Notes = new List<Note>();
        }

        public string Description { get; set; }

        public IEnumerable<Material> Materials { get; set; } 

        public IEnumerable<Note> Notes { get; set; } 


    }
}
