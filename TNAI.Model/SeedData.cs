using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNAI.Model.Entities;

namespace TNAI.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Categories.Any())
            {
                return;
            }

            context.Categories.AddRange(
                new Category()
                {
                    Name = "Komp",
                },
                new Category()
                {
                    Name = "Tablet",
                });

            context.SaveChanges();

            if (context.Products.Any())
            {
                return;
            }

            context.Products.AddRange(
                new Product()
                {
                    Name = "DELL",
                    Price = 10,
                    CategoryId = context.Categories.Where(x => x.Name == "Komp").First().Id,
                },
                new Product()
                {
                    Name = "SAMSUNG",
                    Price = 20,
                    CategoryId = context.Categories.Where(x => x.Name == "Tablet").First().Id,
                },
                new Product()
                {
                    Name = "BenQ",
                    Price = 20,
                    CategoryId = context.Categories.Where(x => x.Name == "Tablet").First().Id,
                }
                );

            context.SaveChanges();    
        }
    }
}
