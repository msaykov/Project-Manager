namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Data;
    using ProjectManager.Models.Notes;
    using ProjectManager.Services.Notes;

    public class NotesController : Controller
    {
        //private readonly ProjectManagerDbContext data;
        private readonly INoteService note;
        

        public NotesController(INoteService note)
        {
            this.note = note;
        }

        [Authorize]
        public IActionResult Add()
            => View();

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddNoteFormModel note , int id)
        {
            if (!ModelState.IsValid)
            {
                return View(note);
            }

            this.note.Create(id, note.Content);

            return RedirectToAction("Details", "Projects", new { id = id });
        }

        
    }
}
