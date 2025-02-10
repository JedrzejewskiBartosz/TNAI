using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models;
using StoreApp.Models.Models;

namespace StoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class WishListController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _UnitOfWork;

        public WishListController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var userId = _UnitOfWork.User.GetUserId(User);
            var wishList = _UnitOfWork.WishList.GetAll().FirstOrDefault(w => w.ApplicationUserId == userId);
            if (wishList == null)
            {
                wishList = new WishListModel { ApplicationUserId = userId };
                _UnitOfWork.WishList.Add(wishList);
            }
            var products = _UnitOfWork.WishList.GetWishListProducts(wishList.Id.ToString());
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToWishList(int productId)
        {
            var userId = _UnitOfWork.User.GetUserId(User);
            var wishList = _UnitOfWork.WishList.GetAll().FirstOrDefault(w => w.ApplicationUserId == userId);
            if (wishList == null)
            {
                wishList = new WishListModel { ApplicationUserId = userId };
                _UnitOfWork.WishList.Add(wishList);
                _UnitOfWork.Save();
            }
            if(wishList.ProductsID.Any(x=>x == productId))
            {
                return Json(new { success = true });
            }
            
            _UnitOfWork.WishList.AddProductToWishList(wishList.Id.ToString(), productId);
            _UnitOfWork.Save();
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult RemoveFromWishList(int productId)
        {
            var userId = _UnitOfWork.User.GetUserId(User);
            var wishList = _UnitOfWork.WishList.GetAll().FirstOrDefault(w => w.ApplicationUserId == userId);
            if (wishList != null)
            {
                _UnitOfWork.WishList.RemoveProductFromWishList(wishList.Id.ToString(), productId);
                _UnitOfWork.Save();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
