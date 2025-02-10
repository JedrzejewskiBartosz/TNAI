using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _db;

        public ReviewRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(ReviewModel review)
        {
            _db.Add(review);
            _db.SaveChanges();
        }

        public IEnumerable<ReviewModel> GetReviewsForProduct(int productId)
        {
            return _db.Review
            .Where(r => r.ProductId == productId)
            .ToList();
        }

        public ReviewModel Get(Expression<Func<ReviewModel, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReviewModel> GetAll(string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(ReviewModel entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ReviewModel> entity)
        {
            throw new NotImplementedException();
        }
    }
}
