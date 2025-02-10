using StoreApp.Models;
using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository.IRepository
{
    public interface IWishListRepository : IRepository<WishListModel>
    {
        void Update(WishListModel WishList);
        void AddProductToWishList(string wishListId, int productId);
        void RemoveProductFromWishList(string wishListId, int productId);
        List<ProductModel> GetWishListProducts(string wishListId);

    }
}
