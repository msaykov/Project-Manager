namespace ProjectManager.Services.Projects
{
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Data.DataConstants;

    public class ProjectService : IProjectService
    {
        private readonly ProjectManagerDbContext data;

        public ProjectService(ProjectManagerDbContext data)
        => this.data = data;

        public ICollection<ProjectServiceModel> MyProjects(string userId)
            => data
                .Projects
                .Where(p => p.Owner.UserId == userId)
                .OrderBy(p => p.EndDate)
                .Select(p => new ProjectServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.ProjectType.Name,
                    Town = p.Town.Name,
                    Owner = p.Owner.Name,
                    EndDate = p.EndDate.ToString("d"),
                    Status = p.Status.Name,
                })
                .ToList();

                

        public ICollection<ProjectServiceModel> All(string status, string type, string townName)
        {
            var projectsQuery = this.data.Projects.AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
            {
                projectsQuery = projectsQuery
                    .Where(s => s.Status.Name == status);
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                projectsQuery = projectsQuery
                    .Where(t => t.ProjectType.Name == type);
            }

            if (!string.IsNullOrWhiteSpace(townName))
            {
                projectsQuery = projectsQuery
                    .Where(tn => tn.Town.Name.ToLower().Contains(townName.ToLower()));
            }

            return projectsQuery
                .OrderBy(p => p.EndDate)
                .Select(p => new ProjectServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.ProjectType.Name,
                    Town = p.Town.Name,
                    Owner = p.Owner.Name,
                    EndDate = p.EndDate.ToString("d"),
                    Status = p.Status.Name,
                })
                .ToList();            
        }

        public ProjectInfoServiceModel Details(int projectId, string userId)
        {
            return this.data
                   .Projects
                   .Where(p => p.Id == projectId)
                   .Select(p => new ProjectInfoServiceModel
                   {
                       Id = projectId,
                       Name = p.Name,
                       Town = p.Town.Name,
                       Type = p.ProjectType.Name,
                       EndDate = p.EndDate.ToString("d"),
                       Owner = p.Owner.Name == null ? "Unassigned" : p.Owner.Name,
                       Status = p.Status.Name,
                       Description = p.Description,
                       Materials = p.Materials,
                       Notes = p.Notes.OrderByDescending(n => n.Id).Take(3),
                       IsOwner = p.Owner.UserId == userId ? true : false,
                   })
                   .FirstOrDefault();
        }

        public EditProjectServiceModel Edit(int projectId)
        {
            var statuses = this.data
                .Statuses
                .Select(s => new StatusesServiceModel 
                { 
                    Id = s.Id,
                    Name = s.Name,                    
                })
                .ToList();

            return this.data
                .Projects
                .Where(p => p.Id == projectId)
                .Select(p => new EditProjectServiceModel
                {
                    Id = projectId,
                    Name = p.Name,
                    Town = p.Town.Name,
                    Type = p.ProjectType.Name,
                    EndDate = p.EndDate.ToString("d"),
                    Owner = p.Owner.Name,
                    Status = p.Status.Name,
                    Description = p.Description,
                    StatusId = p.StatusId,
                    Statuses = statuses,
                })
                .FirstOrDefault();
        }

        public Status GetProjectStatus(string name)
            => this.data
                .Statuses
                .FirstOrDefault(t => t.Name == name);

        public Status GetProjectStatusById(int id)
            => this.data
                .Statuses
                .FirstOrDefault(t => t.Id == id);

        public Town GetProjectTown(string name)
            => this.data
                .Towns
                .FirstOrDefault(t => t.Name == name);

        public ProjectType GetProjectType(string name)
            => this.data
                .ProjectTypes
                .FirstOrDefault(t => t.Name == name);

        public ICollection<string> GetStatuses()
            => this.data
                .Projects
                .Select(s => s.Status.Name)
                .Distinct()
                .ToList();

        public ICollection<string> GetTypes()
            => this.data
                .Projects
                .Select(s => s.ProjectType.Name)
                .Distinct()
                .ToList();

        public Project GetProjectById(int id)
            => this.data
                .Projects
                .FirstOrDefault(p => p.Id == id);

        public int Create(string name, string type, string town, DateTime endDate, string description)
        {
            var currentType = this.GetProjectType(type);
            var projectType = currentType == null ? new ProjectType { Name = type } : currentType;

            var currentTown = this.GetProjectTown(town);
            var projectTown = currentTown == null ? new Town { Name = town } : currentTown;

            var currentStatus = this.GetProjectStatus(DefaultStatusName);
            var projectStatus = currentStatus == null ? new Status { Name = DefaultStatusName } : currentStatus;

            //DateTime date;
            //DateTime.TryParse(endDate, out date);            

            var projectEntity = new Project
            {
                Name = name,
                ProjectType = projectType,
                Town = projectTown,
                EndDate = endDate,
                Status = projectStatus,
                Description = description,
                Owner = null,
            };

            this.data.Projects.Add(projectEntity);
            this.data.SaveChanges();

            return projectEntity.Id; 
        }

        public void Edit(int projectid, string name, string type, string town, string endDate, string description, int statusId)
        {
            var currentType = this.GetProjectType(type);
            var projectType = currentType == null ? new ProjectType { Name = type } : currentType;

            var currentTown = this.GetProjectTown(town);
            var projectTown = currentTown == null ? new Town { Name = town } : currentTown;

            var currentStatus = GetProjectStatusById(statusId);
            var isClosed = currentStatus.Name == "Done" ? true : false;

            DateTime date;
            DateTime.TryParse(endDate, out date);


            var projectEntity = this.GetProjectById(projectid);

            projectEntity.Name = name;
            projectEntity.Town = projectTown;
            projectEntity.ProjectType = projectType;
            projectEntity.EndDate = date;
            projectEntity.Description = description;
            projectEntity.Status = currentStatus;
            projectEntity.IsClosed = isClosed;

            this.data.SaveChanges();
        }
    }
}
