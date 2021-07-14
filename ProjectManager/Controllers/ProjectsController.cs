using Microsoft.AspNetCore.Mvc;
using ProjectManager.Data;
using ProjectManager.Data.Models;
using ProjectManager.Models.Projects;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Controllers
{
    public class ProjectsController : Controller

    {
        private readonly ProjectManagerDbContext data;

        public ProjectsController(ProjectManagerDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddProjectFormModel
        {
            Statuses = this.GetProjectStatuses()
        });

        [HttpPost]
        public IActionResult Add(AddProjectFormModel project)
        {
            if (!this.data.Statuses.Any(s => s.Id == project.StatusId))
            {
                this.ModelState.AddModelError(nameof(project.StatusId), "Status does not exist.");
            }

            if (!ModelState.IsValid)
            {
                project.Statuses = this.GetProjectStatuses();
                return View(project);
            }

            var currentType = this.data
                .Types
                .FirstOrDefault(t => t.Name == project.Type);
            var projectType = currentType == null ? new Type { Name = project.Type } : currentType;

            var currentTown = this.data
                .Towns
                .FirstOrDefault(t => t.Name == project.Town);
            var projectTown = currentTown == null ? new Town { Name = project.Town } : currentTown;

            var currentEmployee = this.data
                .Employees
                .FirstOrDefault(e => e.Name == project.Employee);
            var projectEmployee = currentEmployee == null ? new Employee { Name = project.Employee } : currentEmployee;

            System.DateTime date;
            System.DateTime.TryParse(project.EndDate, out date);

            var projectEntity = new Project
            {
                Name = project.Name,
                Type = projectType,
                Town = projectTown,
                Employee = projectEmployee,
                EndDate = date,
                StatusId = project.StatusId
            };

            this.data.Projects.Add(projectEntity);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<ProjectStatusViewModel> GetProjectStatuses()
            => this.data
            .Statuses
            .Select(s => new ProjectStatusViewModel
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToList();
    }
}
