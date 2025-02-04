using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models;
using StoreApp.Models.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Utility.SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<ApplicationUserModel> applicationUsers = _unitOfWork.User.GetAll()?.ToList();
            return View(applicationUsers);
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUserModel? obj = _unitOfWork.User.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult Getall()
        {
            List<ApplicationUserModel> applicationUsers = _unitOfWork.User.GetAll().ToList();
            return Json(new { data = applicationUsers });
        }

        [HttpDelete] 
        public IActionResult Delete(string id)
        {
            var userModel = _unitOfWork.User.Get(u => u.Id == id);
            if (userModel == null)
            {
                return Json(new { success = false, message = "Error while removing" });
            }

            _unitOfWork.User.Remove(userModel);
            _unitOfWork.Save();

            return Json(new { success = false, message = "Sucess removed" });
        }
        #endregion
    }
}
