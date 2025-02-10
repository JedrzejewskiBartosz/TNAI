using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.Models;
using StoreApp.Models.ViewModels;

namespace StoreApp.Areas.Customer.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(IUnitOfWork unitOfWork, UserManager<ApplicationUserModel> userManager, ILogger<ReviewsController> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            var responseValues = collection.ToDictionary();
            var reviewModel = new ReviewModel(responseValues);
            var user = await _userManager.GetUserAsync(User);
            reviewModel.ApplicationUserId = user.Id;

            _unitOfWork.Review.Add(reviewModel);
            _unitOfWork.Save();

            // Log the productId to confirm it's correct
            _logger.LogInformation($"Review created for ProductId: {reviewModel.ProductId}");

            return RedirectToAction("Details", "Home", new { productId = reviewModel.ProductId });
        }
    }
}
