using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set;}
        public IProductRepository Product { get; private set; }
        public IUserRepository User { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IWishListRepository WishList { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IReviewRepository Review { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            User = new UserRepository(_db);
            Order = new OrderRepository(_db);
            WishList = new WishListRepository(_db);
            ShoppingCart = new ShoppingCartRespository(_db);
            Review = new ReviewRepository(_db);
        }

    public void Save()
        {
            _db.SaveChanges();
        }
    }
}
