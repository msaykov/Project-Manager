namespace ProjectManager.Services.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProjectService
    {
        public ICollection<string> GetStatuses();

        public ICollection<string> GetTypes();
    }
}
