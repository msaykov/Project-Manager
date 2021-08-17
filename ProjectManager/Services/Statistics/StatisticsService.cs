namespace ProjectManager.Services.Statistics
{
    using ProjectManager.Data;
    using ProjectManager.Services.Projects;
    using System;
    using System.Linq;

    public class StatisticsService : IStatisticsService
    {
        private readonly ProjectManagerDbContext data;

        public StatisticsService(ProjectManagerDbContext data)
            => this.data = data;

        public StatisticsServiceModel Total()
        {
            var totalProjects = this.data
                .Projects
                .Count();
            var totalUsers = this.data
                .Users
                .Count();
            var unassignedProjects = this.data
                .Projects
                .Where(p => p.Owner.UserId == null)
                .Count();
            var closedProjects = this.data
                .Projects
                .Where(p => p.IsClosed == true)
                .Count();
            var myExpiringProjects = this.data
                .Projects
                .OrderBy(p => p.EndDate)
                //.Where(p => p.Owner.UserId == userId)
                //.Take(3)
                .Select( p => new ExpiringProjectsServiceModel 
                {
                    ProjectName = p.Name,
                    EndDate = p.EndDate.ToString("dd.MM.yyyy"),
                    RemainingDays = p.EndDate - DateTime.Now
                })
                .ToList();

            return new StatisticsServiceModel
            {
                TotalUsers = totalUsers,
                TotalProjects = totalProjects,
                UnassignedProjects = unassignedProjects,
                ClosedProjects = closedProjects,
                ExpiringProjects = myExpiringProjects,
            };

        }
    }
}
