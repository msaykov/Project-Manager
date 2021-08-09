namespace ProjectManager.Services.Owners
{
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using System.Linq;

    public class OwnerService : IOwnerService
    {
        private readonly ProjectManagerDbContext data;

        public OwnerService(ProjectManagerDbContext data)
            => this.data = data;

        public void Create(int projectId, string name, string phoneNumber, string userId, string userEmail)
        {
            var currentProject = this.data
                .Projects
                .FirstOrDefault(p => p.Id == projectId);

            var currentOwner = this.data
                .Owners
                .FirstOrDefault(o => o.UserId == userId);

            if (currentOwner == null)
            {
                currentOwner = new Owner
                {
                    Name = name,
                    PhoneNumber = phoneNumber,
                    Email = userEmail,
                    UserId = userId,
                };
                this.data.Owners.Add(currentOwner);
            }

            currentProject.Owner = currentOwner;
            this.data.SaveChanges();
        }
    }
}
