using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.Models;
using StoreApp.Models.ViewModels;
using System.Security.Claims;

namespace StoreApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ReviewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(IUnitOfWork unitOfWork, ILogger<ReviewsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                var responseValues = collection.ToDictionary();
                var reviewModel = new ReviewModel(responseValues);
                reviewModel.ByUser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _unitOfWork.Review.Add(reviewModel);
                _unitOfWork.Save();

                _logger.LogInformation("Review added successfully. Redirecting to details page.");

                return RedirectToAction("Details", "Home", new { productId = reviewModel.ProductId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating the review.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
