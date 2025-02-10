using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.DataAcces.Repository;
using StoreApp.Models.Models;

public class WishListRepository : Repository<WishListModel>, IWishListRepository
{
    private readonly ApplicationDbContext _db;

    public WishListRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(WishListModel wishList)
    {
        _db.WishList.Update(wishList);
    }

    public void AddProductToWishList(string wishListId, int productId)
    {
        var wishList = _db.WishList.FirstOrDefault(x => x.Id.ToString() == wishListId);
        if (wishList == null)
        {
            return;
        }
        var product = _db.Products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
        {
            return;
        }
        wishList.ProductsID.Add(productId);
        _db.WishList.Update(wishList);
    }

    public void RemoveProductFromWishList(string wishListId, int productId)
    {
        var wishList = _db.WishList.FirstOrDefault(x => x.Id.ToString() == wishListId);
        if (wishList == null)
        {
            return;
        }
        wishList.ProductsID.Remove(productId);
        _db.WishList.Update(wishList);
    }

    public List<ProductModel> GetWishListProducts(string wishListId)
    {
        var wishList = _db.WishList.FirstOrDefault(x => x.Id.ToString() == wishListId);
        if (wishList == null)
        {
            return new List<ProductModel>();
        }
        return _db.Products.Where(x => wishList.ProductsID.Contains(x.Id)).ToList();
    }
}
