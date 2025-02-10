using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StoreApp.Models;
using StoreApp.Models.Models;
using System.Text.Json;

namespace StoreApp.DataAcces.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ApplicationUserModel> ApplicationUser { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }
        public DbSet<WishListModel> WishList { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCart { get; set; }
        public DbSet<ReviewModel> Review { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUserModel>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.ApplicationUser)
            .HasForeignKey(o => o.ApplicationUserId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUserModel>()
            .HasMany(u => u.Reviews)
            .WithOne(o => o.ApplicationUser)
            .HasForeignKey(o => o.ApplicationUserId);

            modelBuilder.Entity<ApplicationUserModel>()
            .HasOne(u => u.WishList)
            .WithOne(w => w.ApplicationUser)
            .HasForeignKey<WishListModel>(w => w.ApplicationUserId);

            modelBuilder.Entity<ShoppingCartModel>()
               .Property(p => p.ProductsID)
               .HasConversion(
                   v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                   v => JsonSerializer.Deserialize<List<int>>(v, new JsonSerializerOptions())
               );

            modelBuilder.Entity<OrderProductModel>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProductModel>()
                .HasOne(op => op.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProductModel>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Telefony", DisplayOrder = 1 },
                new CategoryModel { Id = 2, Name = "Słuchawki", DisplayOrder = 2 },
                new CategoryModel { Id = 3, Name = "Telewizory", DisplayOrder = 3 }
            );

            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel
                {
                    Id = 1,
                    Name = "Samsung Galaxy S25 Ultra 12/512GB",
                    Description = "",
                    Price = 1580.00,
                    CategoryId = 1,
                    ImageUrl = "/images/product/samsungGalaxyS25.jpg"
                },
                new ProductModel
                {
                    Id = 2,
                    Name = "Hisense 65U6NQ 65\" MINILED 4K VIDAA Dolby Vision Dolby Atmos",
                    Description = "",
                    Price = 739.80,
                    CategoryId = 3,
                    ImageUrl = "/images/product/hisense65U6NQ.jpg"
                },
                new ProductModel
                {
                    Id = 3,
                    Name = "Philips 55PML9008 55\" MINILED 4K",
                    Description = "",
                    Price = 740.00,
                    CategoryId = 3,
                    ImageUrl = "/images/product/philips55PML9008.jpg"
                },
                new ProductModel
                {
                    Id = 4,
                    Name = "Samsung Galaxy Buds3 Pro",
                    Description = "",
                    Price = 172.40,
                    CategoryId = 2,
                    ImageUrl = "/images/product/samsungGalaxyBuds3Pro.jpg"
                },
                new ProductModel
                {
                    Id = 5,
                    Name = "Xiaomi Redmi Note 14 Pro 8/256GB",
                    Description = "",
                    Price = 300.00,
                    CategoryId = 1,
                    ImageUrl = "/images/product/redmiNote14Pro.jpg"
                },
                new ProductModel
                {
                    Id = 6,
                    Name = "Logitech G PRO X",
                    Description = "",
                    Price = 90.0,
                    CategoryId = 2,
                    ImageUrl = "/images/product/logitechGProX.jpg"
                }
            );
        }
    }
}
