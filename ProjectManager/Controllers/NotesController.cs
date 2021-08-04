namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using ProjectManager.Models.Notes;
    using System.Linq;

    public class NotesController : Controller
    {
        private readonly ProjectManagerDbContext data;

        public NotesController(ProjectManagerDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Add()
            => View();

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddNoteFormModel note , int id)
        {
            var currentProject = GetProjectById(id);
            if (!ModelState.IsValid)
            {
                return View(note);
            }

            //var curentStatuses = this.data
            //    .Statuses
            //    .Select(s => s.Name)
            //    .ToList();

            var noteEntity = new Note
            {
                Content = note.Content,                
            };



            currentProject.Notes.Add(noteEntity);
            this.data.SaveChanges();

            return RedirectToAction("Details", "Projects", new { id = id });
        }

        private Project GetProjectById(int id)
           => this.data
           .Projects
           .FirstOrDefault(p => p.Id == id);
    }
}
