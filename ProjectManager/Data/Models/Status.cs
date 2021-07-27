﻿namespace ProjectManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Status
    {
        public Status()
        {
            this.Projects = new List<Project>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Project> Projects { get; private set; }

    }
}
