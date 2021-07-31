namespace ProjectManager.Services.Projects
{
    using ProjectManager.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProjectServise : IProjectService
    {
        private readonly ProjectManagerDbContext data;

        public ProjectServise(ProjectManagerDbContext data)
        => this.data = data;


        public ICollection<string> GetStatuses()
            => this.data
                .Projects
                .Select(s => s.Status.Name)
                .Distinct()
                .ToList();

        public ICollection<string> GetTypes()
            => this.data
                .Projects
                .Select(s => s.ProjectType.Name)
                .Distinct()
                .ToList();

    }
}
