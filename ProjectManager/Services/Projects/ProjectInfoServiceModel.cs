namespace ProjectManager.Services.Projects
{
    using ProjectManager.Data.Models;
    using System.Collections.Generic;

    public class ProjectInfoServiceModel : ProjectServiceModel
    {
        public ProjectInfoServiceModel()
        {
            this.Materials = new List<Material>();
            this.Notes = new List<Note>();
        }

        public string Description { get; set; }

        public IEnumerable<Material> Materials { get; set; }

        public IEnumerable<Note> Notes { get; set; }
    }
}
