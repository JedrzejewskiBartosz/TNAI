using Microsoft.EntityFrameworkCore;
using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Migrations;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models;
using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository
{
    public class OrderRepository : Repository<OrderModel>, IOrderRepository
    {
        private ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<OrderModel> GetAllUserOrders(string userID)
        {
            var orders = _db.Order
               .Include("OrderDetails")
               .Include(o => o.Products)
               .ThenInclude(o => o.Product)
               .Where(o => o.ApplicationUserId == userID)
               .ToList();
            return orders;
        }

        public OrderModel GetFullOrder(int orderId)
        {
            var order = _db.Order
                .Include("OrderDetails")
                .Include(o => o.Products)
                .ThenInclude(o => o.Product)
                .FirstOrDefault(o => o.Id == orderId);
            return order;
        }

        public void Update(OrderModel Order)
        {
            _db.Order.Update(Order);
        }


    }
}
