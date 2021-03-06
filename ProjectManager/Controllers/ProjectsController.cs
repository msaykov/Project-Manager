namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using ProjectManager.Models.Projects;
    using ProjectManager.Infrastructure;
    using static Data.DataConstants;
    using ProjectManager.Services.Projects;
    using System;

    public class ProjectsController : Controller

    {
        //private readonly ProjectManagerDbContext data;
        private readonly IProjectService project;

        public ProjectsController(IProjectService projectService)
        {
            //this.data = data;
            this.project = projectService;
        }

        [Authorize]
        public IActionResult Add() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddProjectFormModel model)
        {
            DateTime date;
            DateTime.TryParse(model.EndDate, out date);

            if (date.Year < DateTime.Now.Year
                || (date.Year == DateTime.Now.Year && date.DayOfYear <= DateTime.Now.DayOfYear))
            {
                this.ModelState.AddModelError(nameof(model.EndDate), "Date is not valid.");
            }


            if (!ModelState.IsValid)
            {
                return View(model);
            }
            

            var projectId = this.project.Create(model.Name, model.Type, model.Town, date, /*model.EndDate,*/ model.Description);

            return RedirectToAction("Details", "Projects", new { id = projectId});
        }

        [Authorize]
        public IActionResult All(string status, string townName, string type)
        {
            var projectQuery = this.project.All(status, type, townName);             
            var projectStatuses = this.project.GetStatuses();
            var projectTypes = this.project.GetTypes();
            return View(new ProjectSearchServiceMoidel
            {
                Projects = projectQuery,
                TownName = townName,
                Statuses = projectStatuses,
                Types = projectTypes,
            });
        }
        [Authorize]
        public IActionResult MyProjects()
        {
            var userId = this.User.GetId();
            return View(project.MyProjects(userId));
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var userId = this.User.GetId();
            return View(project.Details(id, userId));
        }

        //[Authorize]
        //public IActionResult Reports()
        //    => View();

        //[HttpPost]
        //[Authorize]
        //public IActionResult Reports(){}

        [Authorize]
        public IActionResult Edit(int id)
        {
            return View(project.Edit(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, EditProjectServiceModel model)
        {
            DateTime date;
            DateTime.TryParse(model.EndDate, out date);

            if (date.Year < DateTime.Now.Year 
                || (date.Year == DateTime.Now.Year && date.DayOfYear <= DateTime.Now.DayOfYear))
            {
                this.ModelState.AddModelError(nameof(model.EndDate), "Date is not valid.");
            }

            if (!ModelState.IsValid)
            {
                return View(project.Edit(id));
            }

            project.Edit(id, model.Name, model.Type, model.Town, model.EndDate, model.Description, model.StatusId);
            
            return RedirectToAction("Details", "Projects", new { id = id });
        }

        //[Authorize]
        //public IActionResult Close()
        //{
        //    return View();
        //}

        [Authorize]
        public IActionResult Close(int id)
        {
            project.Close(id);

            return RedirectToAction(nameof(All));
        }
        


                        
    }
}
