using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.Models.Models;

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
        public DbSet<WishListModel> WishList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUserModel>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.ApplicationUser)
            .HasForeignKey(o => o.ApplicationUserId);

            modelBuilder.Entity<ApplicationUserModel>()
            .HasOne(u => u.WishList)
            .WithOne(w => w.ApplicationUser)
            .HasForeignKey<WishListModel>(w => w.ApplicationUserId);


            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Category 1", DisplayOrder = 1 },
                new CategoryModel { Id = 2, Name = "Category 2", DisplayOrder = 2 },
                new CategoryModel { Id = 3, Name = "Category 3", DisplayOrder = 3 }
            );

            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { Id = 1, Name = "Prod 1",Description="", Price = 1.99, CategoryId = 2, ImageUrl=""},
                new ProductModel { Id = 2, Name = "Prod 2",Description="", Price = 2.99, CategoryId = 2, ImageUrl=""},
                new ProductModel { Id = 3, Name = "Prod 3",Description="", Price = 3.99, CategoryId = 1, ImageUrl=""}
            );
        }
    }
}
