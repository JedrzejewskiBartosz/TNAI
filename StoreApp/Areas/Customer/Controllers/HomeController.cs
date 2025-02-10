using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models;
using StoreApp.Models.Models;
using StoreApp.Models.ViewModels;
using System.Diagnostics;

namespace StoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string searchQuery)
        {
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category");

            if (!string.IsNullOrEmpty(searchQuery))
            {
                products = products.Where(p => p.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
            }

            HomeViewModel categoryViewModel = new HomeViewModel()
            {
                CategoryList = _unitOfWork.Category.GetAll(),
                ProductModels = products.ToList()
            };
            //IEnumerable<ProductModel>  productsList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(categoryViewModel);
        }
        public IActionResult Details(int productId)
        {
            
            ProductModel productsList = _unitOfWork.Product.Get(u=>u.Id == productId, includeProperties: "Category");
            return View(productsList);

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

        public async Task<IActionResult> Category(int categoryId, string searchQuery)
        {
            var products = _unitOfWork.Product.GetAll().Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                products = products.Where(p => p.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
            }

            var category = _unitOfWork.Category.Get(x => x.Id == categoryId);

            var categoryViewModel = new CategoryViewModel
            {
                CategoryList   = _unitOfWork.Category.GetAll(),
                Category = category,
                ProductModels = products.ToList(),
            };

            return View(categoryViewModel);
        }
        
    }
}
