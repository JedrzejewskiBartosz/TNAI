using StoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using StoreApp.Models.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Utility.SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<CategoryModel> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                _unitOfWork.Save();
                TempData["succes"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CategoryModel? obj = _unitOfWork.Category.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["succes"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    CategoryModel? obj = _unitOfWork.Category.Get(x => x.Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}

        #region API CALLS

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            CategoryModel? obj = _unitOfWork.Category.Get(x => x.Id == id);
            List<ProductModel> productList = _unitOfWork.Product.GetAll().ToList();
            if (obj == null)
            {
                return NotFound();
            }

           productList = productList.Where(x => x.CategoryId == obj.Id).ToList();
           productList.ForEach(x => x.CategoryId = 999);
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["succes"] = "Category removed successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Getall()
        {
            List<CategoryModel> obj = _unitOfWork.Category.GetAll().ToList();
            return Json(new { data = obj });
        }

        #endregion
    }
}
