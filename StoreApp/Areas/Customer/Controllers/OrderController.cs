using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAcces.Migrations;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.ViewModels;
using System.Security.Claims;

namespace StoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(ILogger<OrderController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orders = _unitOfWork.Order.GetAllUserOrders(userId);

            var viewModel = new OrdersViewModel()
            {
                PlacedOrders = orders,
            };

            return View(viewModel);
        }
    }
}
