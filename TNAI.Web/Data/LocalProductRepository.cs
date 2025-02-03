using TNAI.Model.Entities;
using TNAI.Repository.Categories;
using TNAI.Repository.Products;

namespace TNAI.Web.Data;


public class LocalProductRepository : IProductRepository
{
    
    
    private List<Product> _dummyProduct = new List<Product>
    {
     new Product()
     {
         Id = 0,
         Name = "Samsung Galaxy S25 Ultra 12/512GB",
         Description = "Opis tego produktu",
         Price = 4500,
         ImageFile = "samsungGalaxyS25.jpg",
         CategoryId = 0,
         Category = LocalCategoryRepository._dummyCategory.Find(c => c.Id == 0) 
     },
     new Product()
     {
         Id = 1,
         Name = "Hisense 65U6NQ 65\" MINILED 4K VIDAA Dolby Vision Dolby Atmos",
         Description = "Opis tego produktu",
         Price = 2365,
         ImageFile = "hisense65U6NQ.jpg",
         CategoryId = 1,
         Category = LocalCategoryRepository._dummyCategory.Find(c => c.Id == 1) 
     },
     new Product()
     {
         Id = 2,
         Name = "Philips 55PML9008 55\" MINILED 4K",
         Description = "Opis tego produktu",
         Price = 3123,
         ImageFile = "philips55PML9008.jpg",
         CategoryId = 1,
         Category = LocalCategoryRepository._dummyCategory.Find(c => c.Id == 1) 
     },
     new Product()
     {
         Id = 3,
         Name = "Samsung Galaxy Buds3 Pro",
         Description = "Opis tego produktu",
         Price = 231,
         ImageFile = "samsungGalaxyBuds3Pro.jpg",
         CategoryId = 2,
         Category = LocalCategoryRepository._dummyCategory.Find(c => c.Id == 2) 
     },
     new Product()
     {
         Id = 4,
         Name = "Xiaomi Redmi Note 14 Pro 8/256GB",
         Description = "Opis tego produktu",
         Price = 3423,
         ImageFile = "redmiNote14Pro.jpg",
         CategoryId = 1,
         Category = LocalCategoryRepository._dummyCategory.Find(c => c.Id == 1) 
     },
     new Product()
     {
         Id = 5,
         Name = "Logitech G PRO X",
         Description = "Opis tego produktu",
         Price = 1000,
         ImageFile = "logitechGProX.jpg",
         CategoryId = 2,
         Category = LocalCategoryRepository._dummyCategory.Find(c => c.Id == 2) 
     },
    };


    public Task<Product?> GetProductByIdAsync(int id)
    {
        return Task.FromResult(_dummyProduct.First(category => category.Id == id))!;

    }

    public Task<List<Product?>> GetProductByCategoryIdAsync(int categoryId)
    {
        return Task.FromResult(_dummyProduct.Where(category => category.CategoryId == categoryId).ToList())!;
    }
    
    public Task<List<Product>> GetAllProductsAsync()
    {
        return Task.FromResult(_dummyProduct)!;
    }

    public Task<bool> SaveProductAsync(Product product)
    {
        _dummyProduct.Add(product);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteProductAsync(int id)
    {
        _dummyProduct = _dummyProduct.Where(it => it.Id !=  id).ToList();
        return Task.FromResult(true);
    }
}