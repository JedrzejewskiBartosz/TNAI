﻿using Microsoft.AspNetCore.Authorization;
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

        public ReviewsController(IUnitOfWork unitOfWork, UserManager<ApplicationUserModel> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        //// POST: Reviews/Create
        //[HttpPost]
        //public async Task<IActionResult> Create(ReviewModel review)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        review.ApplicationUserId = user.Id;

        //        _unitOfWork.Review.Add(review);
        //        _unitOfWork.Save();

        //        return RedirectToAction("Details", new { id = review.ProductId });
        //    }

        //    return View(review);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            var responseValues = collection.ToDictionary();
            var reviewModel = new ReviewModel(responseValues);
            var user = await _userManager.GetUserAsync(User);
            reviewModel.ApplicationUserId = user.Id;

            _unitOfWork.Review.Add(reviewModel);
            _unitOfWork.Save();

            return RedirectToAction("Details", new { id = reviewModel.ProductId });
        }
    }
}
