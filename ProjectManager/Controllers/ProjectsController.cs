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

            return RedirectToAction(nameof(All));
            //return RedirectToAction("Index", "Home");
        }

        public IActionResult Search() => View();

        public IActionResult All(string status, string townName, string type)
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
                    .Where(t => t.Type.Name == type);
            }

            if (!string.IsNullOrWhiteSpace(townName))
            {
                projectsQuery = projectsQuery
                    .Where(tn => tn.Town.Name.ToLower().Contains(townName.ToLower()));
            }

            var allProjects = projectsQuery
                .OrderByDescending(p => p.Id)
                .Select(p => new ListProjectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type.Name,
                    Town = p.Town.Name,
                    //Employee = p.Employee.Name,
                    EndDate = p.EndDate.ToString("d"),
                    Status = p.Status.Name
                })
                .ToList();

            var projectStatuses = this.data
                .Projects
                .Select(s => s.Status.Name)
                .Distinct()
                .ToList();

            var projectTypes = this.data
               .Projects
               .Select(s => s.Type.Name)
               .Distinct()
               .ToList();

            return View(new ProjectsSearchViewModel
            {
                Projects = allProjects,
                TownName = townName,
                Statuses = projectStatuses,
                Types = projectTypes,
            });
        }

        public IActionResult Details(int id)
        {
            var currentProject = this.data
                .Projects
                .FirstOrDefault(p => p.Id == id);

            return View(new ProjectInfoViewModel
            {
                Name = currentProject.Name,
                Type = currentProject.Type.Name,
                Town = currentProject.Town.Name,
                Employee = currentProject.Employee.Name,
                EndDate = currentProject.EndDate.ToString("d"),
                Status = currentProject.Status.Name,
                //Materials = currentProject.Pro
            });
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
