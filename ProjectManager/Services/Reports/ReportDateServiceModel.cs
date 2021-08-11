namespace ProjectManager.Services.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReportDateServiceModel
    {
        public string ProjectName { get; set; }

        public string Owner { get; set; }

        public string EndDate { get; set; }

        public TimeSpan RemainingDays { get; set; }
    }
}
