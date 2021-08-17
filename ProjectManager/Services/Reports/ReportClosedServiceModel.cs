namespace ProjectManager.Services.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReportClosedServiceModel
    {
        public string ProjectName { get; set; }

        public string Owner { get; set; }

        public string StartDate { get; set; }

        public string ClosingDate { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
