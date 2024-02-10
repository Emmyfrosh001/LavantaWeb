using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AydinogluLavender.Controllers
{
    [Authorize(Roles = "AdmAL")]//Aouhorize komutunu kontroller seviyesine çıkarma
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        UserValidator userValidator = new UserValidator();

        // GET: User
        public ActionResult Index()
        {
            var uservalue=um.GetAllList(); 
            return View(uservalue);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User kullanici)
        {
            ValidationResult results = userValidator.Validate(kullanici);
            if (results.IsValid)
            {
                um.AddUserBl(kullanici);
                return RedirectToAction("/Index","User");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var result=um.GetByID(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            ValidationResult results = userValidator.Validate(user);
            if (results.IsValid)
            {
                um.UpdateUserBl(user);
                return RedirectToAction("/Index", "User");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
    }
}