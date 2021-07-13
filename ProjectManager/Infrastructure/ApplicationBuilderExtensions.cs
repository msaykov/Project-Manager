using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Data;
using ProjectManager.Data.Models;
using System.Linq;

namespace ProjectManager.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var data = scopedServices.ServiceProvider.GetService<ProjectManagerDbContext>();
            data.Database.Migrate();

            SeedStatuses(data);

            return app;
        }

        private static void SeedStatuses(ProjectManagerDbContext data)
        {
            if (data.Statuses.Any())
            {
                return;
            }
            data.Statuses.AddRange(new[] 
            {
                new Status{ Name= "New"},            
                new Status{ Name= "In Progres"},            
                new Status{ Name= "Waiting"},            
                new Status{ Name= "Done"},            
            });

            data.SaveChanges();
        }
    }
}
