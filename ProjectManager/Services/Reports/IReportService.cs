namespace ProjectManager.Services.Reports
{
    using System.Collections.Generic;

    public interface IReportService
    {
        ICollection<ReportCostServiceModel> ByCost();
        ICollection<ReportDateServiceModel> ByEndDate();
        ICollection<ReportClosedServiceModel> Closed();
    }
}
