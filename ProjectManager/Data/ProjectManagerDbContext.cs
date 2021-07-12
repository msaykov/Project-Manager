using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Models;

namespace ProjectManager.Data
{
    public class ProjectManagerDbContext : DbContext//: IdentityDbContext
    {
        
        public ProjectManagerDbContext(DbContextOptions<ProjectManagerDbContext> options)
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<ProjectsMaterial>()
                .HasOne(p => p.Project)
                .WithMany(p => p.Materials)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ProjectsMaterial>()
                .HasOne(p => p.Material)
                .WithMany(m => m.Projects)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
