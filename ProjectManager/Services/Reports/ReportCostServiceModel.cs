namespace ProjectManager.Services.Reports
{
    using ProjectManager.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReportCostServiceModel
    {
        public string ProjectName { get; set; }

        public string Owner { get; set; }

        public ICollection<MaterialInfoServiceModel> MaterialsInfo { get; set; }

        public decimal Cost { get; set; }


    }
}
