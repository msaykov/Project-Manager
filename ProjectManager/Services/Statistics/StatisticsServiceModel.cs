namespace ProjectManager.Services.Statistics
{
    using ProjectManager.Services.Projects;
    using System.Collections.Generic;

    public class StatisticsServiceModel
    {
        public int TotalUsers { get; set; }

        public int TotalProjects { get; set; }

        public int UnassignedProjects { get; set; }

        public int ClosedProjects { get; set; }

        public ICollection<ExpiringProjectsServiceModel> ExpiringProjects { get; set; }
    }
}
