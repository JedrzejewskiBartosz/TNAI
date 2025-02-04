using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class WishListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
