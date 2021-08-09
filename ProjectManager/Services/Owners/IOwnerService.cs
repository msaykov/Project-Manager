namespace ProjectManager.Services.Owners
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IOwnerService
    {
        void Create(int projectId, string name, string phoneNumber, string userId, string userEmail);
    }
}
