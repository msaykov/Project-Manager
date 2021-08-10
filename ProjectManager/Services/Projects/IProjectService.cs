namespace ProjectManager.Services.Projects
{
    using ProjectManager.Data.Models;
    using System.Collections.Generic;

    public interface IProjectService
    {
        ICollection<ProjectServiceModel> All(string status, string type, string townName);

        ICollection<ProjectServiceModel> MyProjects(string userId);

        ProjectInfoServiceModel Details(int projectId , string userId);

        EditProjectServiceModel Edit(int projectId);

        int Create(string name, string type, string town, string date, string description);

        void Edit(int projectId, string name, string type, string town, string date, string description, int statusId);
        
        Project GetProjectById(int id);

        ProjectType GetProjectType(string name);

        Town GetProjectTown(string name);

        Status GetProjectStatus(string name);

        ICollection<string> GetStatuses();

        ICollection<string> GetTypes();


    }
}
