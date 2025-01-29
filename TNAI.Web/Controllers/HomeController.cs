using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TNAI.Dto.Catrgories;
using TNAI.Repository.Categories;
using TNAI.Repository.Products;
using TNAI.Web.Models;

namespace TNAI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryCategoryRepository,
            IProductRepository productCategoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryCategoryRepository;
            _productRepository = productCategoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["comment"] = "Heloł";
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            ViewData["categories"] = categories;
            var allProducts = await _productRepository.GetAllProductsAsync();

            var model = new HomeViewModel()
            {
                products = allProducts.ConvertAll(p => new ProductDto(p))
            };

            return View(model);
        }

        public async Task<IActionResult> Product(int id)
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            ViewData["categories"] = categories;

            var product = await _productRepository.GetProductByIdAsync(id);
            var productDto = new ProductDto(product);
            
            ViewData["Title"] = productDto.Name;
            
            return View(productDto);
        }
        public async Task<IActionResult> Category(int categoryId)
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            ViewData["categories"] = categories;

            var selectedCategory = categories.First(c => c.Id == categoryId)!;
            
            var product = await _productRepository.GetProductByCategoryIdAsync(categoryId);
            var productDto = product.ConvertAll(it => new ProductDto(it));

            ViewData["Title"] = selectedCategory.Name;

            var model = new CategoryViewModel()
            {
                products = productDto,
                category = selectedCategory,
            };
            
            return View(model);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}