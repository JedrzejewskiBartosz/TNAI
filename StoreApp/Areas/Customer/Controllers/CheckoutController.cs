using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.Models;
using StoreApp.Models.ViewModels;
using System.Security.Claims;

namespace StoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CheckoutController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public CheckoutController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        // GET: CheckoutController
        public ActionResult Index()
        {
            var model = new CheckoutViewModel { Products = [] };
            string cartID = Request.Cookies["cartID"];

            if (cartID == null)
            {
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

        public ActionResult Summary(int orderId)
        {
            var order = _unitOfWork.Order.Get(it => it.Id == orderId, "OrderDetails,Products");

            var viewModel = new OrderViewModel
            {
                Products = order.Products,
                OrderDetails = order.OrderDetails,
            };

            return View(viewModel);
        }

        // POST: CheckoutController/Buy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(IFormCollection collection)
        {
            try
            {
                var responseValues = collection.ToDictionary();
                var details = new OrderDetailsModel(responseValues);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // User ID
                string cartID = Request.Cookies["cartID"];

                var products = _unitOfWork.ShoppingCart.GetCartProducts(cartID);
                var newOrder = new OrderModel(details, products, userId);

                
                //shopping cart should be cleaned after
                _unitOfWork.Order.Add(newOrder);
                _unitOfWork.Save();
                Response.Cookies.Delete("cartID");


                return RedirectToAction(nameof(Summary), new
                {
                    orderId = newOrder.Id,
                });
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
