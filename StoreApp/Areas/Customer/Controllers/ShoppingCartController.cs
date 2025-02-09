using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.ViewModels;

namespace StoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Cart")]
    public class ShoppingCartController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        // GET: Cart
        public ActionResult Index()
        {
            var model = new ShoppingCartViewModel { Products = [] };
            string cartID = Request.Cookies["cartID"];

            if (cartID == null) {
                return View(model);
            }

            var cart = _unitOfWork.ShoppingCart.Get(x => x.ShoppingCartId == cartID);
            if (cart == null)
            {
                return View(model);
            }
            else
            {
                var products = _unitOfWork.Product.ListProducts(cart.ProductsID);
                model.Products = products;
            }

            return View(model);
        }

        // POST: Cart/AddItem/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(int productId)
        {
            string cartID = Request.Cookies["cartID"];

            if (cartID == null)
            {
                cartID = _unitOfWork.ShoppingCart.CreateNewCart();
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true, // Prevent JavaScript access
                    //Secure = true,   // Use only on HTTPS
                    Expires = DateTime.UtcNow.AddDays(7) // Expiration time
                };

                // Store cart ID in a cookie
                Response.Cookies.Append("cartID", cartID, cookieOptions);
            }

            _unitOfWork.ShoppingCart.AddProductToCart(cartID, productId);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
