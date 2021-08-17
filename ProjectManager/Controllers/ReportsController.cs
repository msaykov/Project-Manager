namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Services.Reports;

    public class ReportsController : Controller
    {
        private readonly IReportService report;


        public ReportsController(IReportService report)
        {
            this.report = report;
        }

        [Authorize]
        public IActionResult All()
            => View();

        [Authorize]
        public IActionResult ByCost()
            => View(report.ByCost());

        [Authorize]
        public IActionResult ByEndDate()
            => View(report.ByEndDate());

        [Authorize]
        public IActionResult Closed()
           => View(report.Closed());


    }
}
