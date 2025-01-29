using TNAI.Model.Entities;
using TNAI.Repository.Categories;



namespace TNAI.Web.Data
{
    public class LocalCategoryRepository : ICategoryRepository
    {
        static public List<Category> _dummyCategory = new List<Category>
        {
            new Category()
            {
                Id = 0,
                Name = "Telefony",
            },
            new Category()
            {
                Id = 1,
                Name = "Telewizory",
            },
            new Category()
            {
                Id = 2,
                Name = "Słuchawki"
            }
        };
        public Task<Category?> GetCategoryByIdAsync(int id)
        {
            return Task.FromResult(_dummyCategory.First(category => category.Id == id))!;
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            return Task.FromResult(_dummyCategory)!;
        }

        public Task<bool> SaveCategorysAsync(Category category)
        {
            _dummyCategory.Add(category);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteCategorysAsync(int id)
        {
            _dummyCategory = _dummyCategory.Where(it => it.Id != id).ToList();
            return Task.FromResult(true);
        }
    }
}