using Microsoft.AspNetCore.Mvc;
using ProjectManager.Data;
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
            return View();
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
