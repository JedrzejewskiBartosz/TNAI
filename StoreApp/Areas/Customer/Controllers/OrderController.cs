using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAcces.Migrations;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.ViewModels;

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
            var order = _unitOfWork.Order.GetAll("OrderDetails,Products").ToList();

            var viewModel = new OrdersViewModel()
            {
                PlacedOrders = order,
            };

            return View(viewModel);
        }
    }
}
