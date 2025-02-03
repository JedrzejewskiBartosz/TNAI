using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TNAI.Model.Entities;
using static System.Net.Mime.MediaTypeNames;

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
                    Name = "Telefony"
                },
                new Category()
                {
                    Name = "Telewizory"
                },
                new Category()
                {
                    Name = "Słuchawki"
                }
            );

            context.SaveChanges();

            if (context.Products.Any())
            {
                return;
            }

            context.Products.AddRange(
                new Product()
                {
                    Name = "Samsung Galaxy S25 Ultra 12/512GB",
                    Description = "Opis tego produktu",
                    Price = 4500,
                    ImageFile = "samsungGalaxyS25.jpg",
                    CategoryId = context.Categories.Where(x => x.Name == "Telefony").First().Id,
                },
                new Product()
                {
                    Name = "Hisense 65U6NQ 65\" MINILED 4K VIDAA Dolby Vision Dolby Atmos",
                    Description = "Opis tego produktu",
                    Price = 2365,
                    ImageFile = "hisense65U6NQ.jpg",
                    CategoryId = context.Categories.Where(x => x.Name == "Telewizory").First().Id,

                },
                new Product()
                {
                    Name = "Philips 55PML9008 55\" MINILED 4K",
                    Description = "Opis tego produktu",
                    Price = 3123,
                    ImageFile = "philips55PML9008.jpg",
                    CategoryId = context.Categories.Where(x => x.Name == "Telewizory").First().Id,
                },
                new Product()
                {
                    Name = "Samsung Galaxy Buds3 Pro",
                    Description = "Opis tego produktu",
                    Price = 231,
                    ImageFile = "samsungGalaxyBuds3Pro.jpg",
                    CategoryId = context.Categories.Where(x => x.Name == "Słuchawki").First().Id,
                },
                new Product()
                {
                    Name = "Xiaomi Redmi Note 14 Pro 8/256GB",
                    Description = "Opis tego produktu",
                    Price = 3423,
                    ImageFile = "redmiNote14Pro.jpg",
                    CategoryId = context.Categories.Where(x => x.Name == "Telewizory").First().Id,
                },
                new Product()
                {
                    Name = "Logitech G PRO X",
                    Description = "Opis tego produktu",
                    Price = 1000,
                    ImageFile = "logitechGProX.jpg",
                    CategoryId = context.Categories.Where(x => x.Name == "Słuchawki").First().Id,
                }
            );

            context.SaveChanges();    
        }
    }
}
