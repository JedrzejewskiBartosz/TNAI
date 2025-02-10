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
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUserModel> _userManager;

        public ReviewsController(ApplicationDbContext context, UserManager<ApplicationUserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST: Reviews/Create
        [HttpPost]
        public async Task<IActionResult> Create(ReviewModel review)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                review.ApplicationUserId = user.Id;

                _context.Review.Add(review);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Products", new { id = review.ProductId });
            }

            return View(review);
        }
    }
}
