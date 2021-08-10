namespace ProjectManager.Services.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReportServiceModel
    {
        public string ProjectName { get; set; }

        public string Owner { get; set; }

        public string EndDate { get; set; }

        public string Status { get; set; }

        public string Duration { get; set; }

        public decimal Cost { get; set; }


    }
}
