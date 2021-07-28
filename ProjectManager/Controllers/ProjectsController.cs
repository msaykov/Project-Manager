namespace ProjectManager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using ProjectManager.Models.Projects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    public class ProjectsController : Controller

    {
        private readonly ProjectManagerDbContext data;

        public ProjectsController(ProjectManagerDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Add() => View();

        //public IActionResult Add() => View(new AddProjectFormModel
        //{
        //    Statuses = this.GetProjectStatuses()
        //});

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddProjectFormModel project)
        {
            //if (!this.data.Statuses.Any(s => s.Id == project.StatusId))
            //{
            //    this.ModelState.AddModelError(nameof(project.StatusId), "Status does not exist.");
            //}

            if (!ModelState.IsValid)
            {
                //project.Statuses = this.GetProjectStatuses();
                return View(project);
            }

            var currentType = this.data
                .ProjectTypes
                .FirstOrDefault(t => t.Name == project.Type);
            var projectType = currentType == null ? new ProjectType { Name = project.Type } : currentType;

            var currentTown = this.data
                .Towns
                .FirstOrDefault(t => t.Name == project.Town);
            var projectTown = currentTown == null ? new Town { Name = project.Town } : currentTown;

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userName = this.User.FindFirst(ClaimTypes.Email).Value;
            //var userPhone = this.User.FindFirst(ClaimTypes.Email).Value;
            
            

            var currentStatus = this.data
               .Statuses
               .FirstOrDefault(s => s.Name == "New");
            var projectStatus = currentStatus == null ? new Status { Name = "New" } : currentStatus;

            var currentOwner = this.data
                .Owners
                .FirstOrDefault(e => e.UserId == userId);
            var projectOwner = currentOwner == null ? new Owner { UserId = userId , Name = userName } : currentOwner;

            //var currentEmployee = this.data
            //    .Employees
            //    .FirstOrDefault(e => e.Name == project.Employee);
            //var projectEmployee = currentEmployee == null ? new Employee { Name = project.Employee } : currentEmployee;

            DateTime date;
            DateTime.TryParse(project.EndDate, out date);

            var projectEntity = new Project
            {
                Name = project.Name,
                ProjectType = projectType,
                Town = projectTown,
                EndDate = date,
                Status = projectStatus,
                Description = project.Description,
                Owner = projectOwner,
            };

            this.data.Projects.Add(projectEntity);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
            //return RedirectToAction("Index", "Home");
        }

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
                    .Where(t => t.ProjectType.Name == type);
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
                    Type = p.ProjectType.Name,
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
               .Select(s => s.ProjectType.Name)
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
            var currentProject = GetProjectById(id);

            var projectTown = this.data
                .Towns
                .FirstOrDefault(p => p.Id == currentProject.TownId);

            var projectType = this.data
                .ProjectTypes
                .FirstOrDefault(p => p.Id == currentProject.ProjectTypeId);

            var projectStatus = this.data
                .Statuses
                .FirstOrDefault(p => p.Id == currentProject.StatusId);

            var projectOwner= this.data
                .Owners
                .FirstOrDefault(p => p.Id == currentProject.OwnerId);


            return View(new ProjectInfoViewModel
            {
                Id = id,
                Name = currentProject.Name,
                EndDate = currentProject.EndDate.ToString("d"),
                Status = projectStatus.Name,
                Town = projectTown.Name,
                Type = projectType.Name,
                Owner = projectOwner.Name,
                Description = currentProject.Description,
                //Materials = currentProject.Pro
            });
        }

        public IActionResult Edit(int id) 
        {
            var currentProject = GetProjectById(id);

            var projectTown = this.data
                .Towns
                .FirstOrDefault(p => p.Id == currentProject.TownId);

            var projectType = this.data
                .ProjectTypes
                .FirstOrDefault(p => p.Id == currentProject.ProjectTypeId);

            var projectStatus = this.data
                .Statuses
                .FirstOrDefault(p => p.Id == currentProject.StatusId);

            var projectOwner = this.data
                .Owners
                .FirstOrDefault(p => p.Id == currentProject.OwnerId);


            return View(new EditProjectViewModel
            {
                Id = id,
                Name = currentProject.Name,
                Town = projectTown.Name,
                Type = projectType.Name,
                Owner = projectOwner.Name,
                EndDate = currentProject.EndDate.ToString("d"),
                Status = projectStatus.Name,
                Description = currentProject.Description,
            });
        }

        [HttpPost]
        public IActionResult Edit(int id , EditProjectViewModel project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }


            
            var currentType = this.data
                .ProjectTypes
                .FirstOrDefault(t => t.Name == project.Type);
            var projectType = currentType == null ? new ProjectType { Name = project.Type } : currentType;

            var currentTown = this.data
                .Towns
                .FirstOrDefault(t => t.Name == project.Town);
            var projectTown = currentTown == null ? new Town { Name = project.Town } : currentTown;

            System.DateTime date;
            System.DateTime.TryParse(project.EndDate, out date);




            var currentProject = GetProjectById(id);

            currentProject.Name = project.Name;
            currentProject.Town = projectTown;
            currentProject.ProjectType = projectType;
            //currentProject.Owner.Name = project.Owner;
            currentProject.EndDate = date;
            //currentProject.Status.Name = project.Status;
            currentProject.Description = project.Description;

            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
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

        private Project GetProjectById(int id)
            => this.data
            .Projects
            .FirstOrDefault(p => p.Id == id);
    }
}
