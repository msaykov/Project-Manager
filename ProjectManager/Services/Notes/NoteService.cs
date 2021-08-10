namespace ProjectManager.Services.Notes
{
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using System;
    using System.Linq;

    public class NoteService : INoteService
    {
        private readonly ProjectManagerDbContext data;

        public NoteService(ProjectManagerDbContext data)
            => this.data = data;

        public void Create(int projectId, string content)
        {
            var currentProject = GetProjectById(projectId);

            var noteEntity = new Note
            {
               Content = content,
               CreationDate = DateTime.UtcNow.ToString("dd.MM.yyyy - hh:mm:ss"),
            };

            currentProject.Notes.Add(noteEntity);
            this.data.SaveChanges();
        }

        public Project GetProjectById(int id)
             => this.data
                .Projects
                .FirstOrDefault(p => p.Id == id);
    }
}
