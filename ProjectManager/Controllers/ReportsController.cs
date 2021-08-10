namespace ProjectManager.Controllers
{
    using ProjectManager.Services.Reports;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReportsController
    {
        private readonly IReportService report;


        public ReportsController(IReportService report)
        {
            this.report = report;
        }
    }
}
