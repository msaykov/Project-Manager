namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using ProjectManager.Infrastructure;
    using ProjectManager.Models.Owners;
    using ProjectManager.Services.Owners;
    using System.Linq;
    using System.Security.Claims;

    public class OwnersController : Controller
    {
        private readonly IOwnerService owner;

        public OwnersController(IOwnerService owner)
            => this.owner = owner;

        [Authorize]
        public IActionResult Update() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Update(UpdateOwnerFormModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = this.User.GetId();
            var userEmail = this.User.GetEmail();

            this.owner.Create(id, model.Name, model.PhoneNumber, userId, userEmail);

            return RedirectToAction("Details", "Projects", new { id = id });
            //return RedirectToAction(nameof(ProjectsController.Details), new { id = id });
        }


    }
}
