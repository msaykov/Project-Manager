namespace ProjectManager.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using ProjectManager.Data;
    using ProjectManager.Data.Models;
    using ProjectManager.Models.Projects;
    using ProjectManager.Infrastructure;
    using static Data.DataConstants;

    public class ProjectsController : Controller

    {
        private readonly ProjectManagerDbContext data;

        public ProjectsController(ProjectManagerDbContext data)
            => this.data = data;

        [Authorize]
        public IActionResult Add() => View();
        //{
        //    var userId = this.User.GetId(); 
        //    return ...
        //}


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

            var userId = this.User.GetId();
            //var userEmail = this.User.FindFirst(ClaimTypes.Email).Value;


            var currentStatus = this.data
               .Statuses
               .FirstOrDefault(s => s.Name == DefaultStatusName);
            var projectStatus = currentStatus == null ? new Status { Name = DefaultStatusName } : currentStatus;

            //var currentOwner = this.data
            //    .Owners
            //    .FirstOrDefault(e => e.UserId == userId);
            //var projectOwner = currentOwner == null ? new Owner { UserId = userId , Name = userName } : currentOwner;



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
                Owner = null,
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
                    Owner = p.Owner.Name,
                    EndDate = p.EndDate.ToString("d"),
                    Status = p.Status.Name,                    
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
        [Authorize]
        public IActionResult MyProjects()
        {
            var userId = this.User.GetId();

            return View(this.data
                .Projects
                .Where(p => p.Owner.UserId == userId)
                .OrderByDescending(p => p.EndDate)
                .Select(p => new ListProjectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.ProjectType.Name,
                    Town = p.Town.Name,
                    Owner = p.Owner.Name,
                    EndDate = p.EndDate.ToString("d"),
                    Status = p.Status.Name,
                })
                .ToList());


        }

        public IActionResult Details(int id)
        {
            return View(this.data
                 .Projects
                 .Where(p => p.Id == id)
                 .Select(p => new ProjectInfoViewModel
                 {
                     Id = id,
                     Name = p.Name,
                     Town = p.Town.Name,
                     Type = p.ProjectType.Name,
                     EndDate = p.EndDate.ToString("d"),
                     Owner = p.Owner.Name == null ? "Unassigned" : p.Owner.Name,
                     Status = p.Status.Name,
                     Description = p.Description,
                     Materials = p.Materials,
                     Notes = p.Notes.OrderByDescending(n => n.Id).Take(5),
                     IsOwner = p.Owner.UserId == this.User.GetId() ? true : false,
                 })
                 .FirstOrDefault());

        }

        public IActionResult Edit(int id)
        {
            return View(this.data
                .Projects
                .Where(p => p.Id == id)
                .Select(p => new EditProjectViewModel
                {
                    Id = id,
                    Name = p.Name,
                    Town = p.Town.Name,
                    Type = p.ProjectType.Name,
                    EndDate = p.EndDate.ToString("d"),
                    Owner = p.Owner.Name,
                    Status = p.Status.Name,
                    Description = p.Description,
                })
                .FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(int id, EditProjectViewModel project)
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

            DateTime date;
            DateTime.TryParse(project.EndDate, out date);




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
