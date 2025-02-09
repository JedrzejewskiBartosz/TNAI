using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCartModel>
    {
        void Update(ShoppingCartModel ShoppingCart);

        void AddProductToCart(string cartID, int productId);
        void RemoveProductFromCart(string cartID, int productId);
        public List<ProductModel> GetCartProducts(string cartID);
    }
}
