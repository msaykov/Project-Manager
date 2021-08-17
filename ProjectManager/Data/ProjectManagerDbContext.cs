namespace ProjectManager.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ProjectManager.Data.Models;

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
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Material>()
                .Property(m => m.Price)
                .HasColumnType("decimal(5,3)");

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
                .HasOne(p => p.ProjectType)
                .WithMany(t => t.Projects)
                //.HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Owner>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Owner>(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Material>()
                .HasOne(p => p.MaterialType)
                .WithMany(t => t.Materials)
                //.HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Note>()
                .HasOne(n => n.Project)
                .WithMany(t => t.Notes)
                //.HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }


    }
}
