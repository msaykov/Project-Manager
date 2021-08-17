namespace ProjectManager.Services.Projects
{
    using System;

    public class ExpiringProjectsServiceModel
    {
        public string ProjectName { get; set; }

        public string EndDate { get; set; }

        public TimeSpan RemainingDays { get; set; }
    }
}
