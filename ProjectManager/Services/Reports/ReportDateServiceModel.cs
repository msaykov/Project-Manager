﻿namespace ProjectManager.Services.Reports
{
    using System;

    public class ReportDateServiceModel
    {
        public string ProjectName { get; set; }

        public string Owner { get; set; }

        public string EndDate { get; set; }

        public TimeSpan RemainingDays { get; set; }
    }
}
