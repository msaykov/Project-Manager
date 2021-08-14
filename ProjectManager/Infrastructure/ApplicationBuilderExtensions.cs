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
            SeedMaterialTypes(data);
            SeedMaterials(data);

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
                new Status{ Name= "Assigned"},            
                new Status{ Name= "In Progres"},            
                new Status{ Name= "On Hold"},            
                new Status{ Name= "Testing"},            
                new Status{ Name= "Done"},            
            });

            data.SaveChanges();
        }

        private static void SeedMaterialTypes(ProjectManagerDbContext data)
        {
            if (!data.MaterialTypes.Any())
            {
                return;
            }
            data.MaterialTypes.AddRange(new[]
            {
                new MaterialType {Name = "Cable"},
                new MaterialType {Name = "ODF"},
                new MaterialType {Name = "Adaptor"},
                new MaterialType {Name = "Pigtail"},
                new MaterialType {Name = "Pigtail"},
            });

            data.SaveChanges();

        }

        private static void SeedMaterials(ProjectManagerDbContext data)
        {
            if (data.Materials.Any())
            {
                return;
            }
            data.Materials.AddRange(new[]
            {
                new Material{Name = "ODF 24FO duplex", MaterialType = new MaterialType{Name = "ODF" }, Price = 45.00M, SapNumber = 10001, Quantity = 0},
                new Material{Name = "Optical Cable 24FO", MaterialType = new MaterialType{Name = "Cable" }, Price = 2.96M, SapNumber = 10002, Quantity = 0},
                new Material{Name = "Adaptor SC/PC simplex", MaterialType = new MaterialType{Name = "Adaptor" }, Price = 5.45M, SapNumber = 10003, Quantity = 0},
                new Material{Name = "Pigtail SC/PC 1m", MaterialType = new MaterialType{Name = "Pigtail" }, Price = 6.20M, SapNumber = 10004, Quantity = 0},
                new Material{Name = "Patchcord SC/PC - SC/PC 3m", MaterialType = new MaterialType{Name = "Patchcord" }, Price = 10M, SapNumber = 10005, Quantity = 0},
            });

            data.SaveChanges();
        }
    }
}
