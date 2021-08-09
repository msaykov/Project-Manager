namespace ProjectManager.Services.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface INoteService
    {
        void Create(int projectId, string content);
    }
}
