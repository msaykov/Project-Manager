namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Infrastructure;
    using ProjectManager.Models;
    using ProjectManager.Services.Statistics;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;

        public HomeController(IStatisticsService statistics)
        {
            this.statistics = statistics;
        }


        public IActionResult Index()
        {
            //var userId = this.User.GetId();
            //var info = this.statistics.Total(userId);
            var info = this.statistics.Total();
            return View(info);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });


    }
}
