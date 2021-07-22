using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Models;

namespace ProjectManager.Data
{
    public class ProjectManagerDbContext : IdentityDbContext
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
        public DbSet<Owner> Owners { get; set; }
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
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ProjectsMaterial>()
                .HasOne(p => p.Material)
                .WithMany(m => m.Projects)
                .HasForeignKey(m => m.MaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Project>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Projects)
                //.HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Project>()
                .HasOne(p => p.Status)
                .WithMany(s => s.Projects)
                //.HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Project>()
                .HasOne(p => p.Town)
                .WithMany(t => t.Projects)
                //.HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Project>()
                .HasOne(p => p.Type)
                .WithMany(t => t.Projects)
                //.HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Owner>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Owner>(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }


    }
}
