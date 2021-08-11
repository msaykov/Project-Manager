namespace ProjectManager.Services.Reports
{
    using ProjectManager.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReportService : IReportService
    {
        private readonly ProjectManagerDbContext data;

        public ReportService(ProjectManagerDbContext data)
            => this.data = data;

        public ICollection<ReportCostServiceModel> ByCost()
        {

            var projects = this.data
                           .Projects
                           .Select(p => new ReportCostServiceModel
                           {
                               ProjectName = p.Name,
                               Owner = p.Owner.Name,
                               MaterialsInfo = p.Materials.Select(m => new MaterialInfoServiceModel { Price = m.Price, Quantity = m.Quantity }).ToList(),
                               
                           })
                           .ToList();
            foreach (var project in projects)
            {
                project.Cost = project.MaterialsInfo.Select(mi => mi.Price * mi.Quantity).Sum();
            }

            return projects.OrderByDescending(c => c.Cost).ToList();

        }

        public ICollection<ReportDateServiceModel> ByEndDate()
            => this.data
                .Projects
                .OrderBy(p => p.EndDate)
                .Select(p => new ReportDateServiceModel
                {
                    ProjectName = p.Name,
                    Owner = p.Owner.Name,
                    EndDate = p.EndDate.ToString("dd.MM.yyyy"),
                    RemainingDays = p.EndDate - DateTime.Now,
                })
                .ToList();
    }
}
