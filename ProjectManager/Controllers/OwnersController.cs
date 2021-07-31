namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using ProjectManager.Infrastructure;
    using ProjectManager.Models.Owners;
    using System.Linq;
    using System.Security.Claims;

    public class OwnersController : Controller
    {
        private readonly ProjectManagerDbContext data;

        public OwnersController(ProjectManagerDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Update() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Update(UpdateOwnerFormModel owner, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(owner);
            }

            var currentProject = this.data
                .Projects
                .FirstOrDefault(p => p.Id == id);


            var userId = this.User.GetId();
            var userEmail = this.User.FindFirst(ClaimTypes.Email).Value;

            var currentOwner = this.data
                .Owners
                .FirstOrDefault(o => o.UserId == userId);

            if (currentOwner == null)
            {
                currentOwner = new Owner
                {
                    Name = owner.Name,
                    PhoneNumber = owner.PhoneNumber,
                    Email = userEmail,
                    UserId = userId,
                };
                this.data.Owners.Add(currentOwner);
            }



            currentProject.Owner = currentOwner;
            this.data.SaveChanges();

            return RedirectToAction("Details", "Projects", new { id = id });
            //return RedirectToAction(nameof(ProjectsController.Details), new { id = id });
        }


    }
}
