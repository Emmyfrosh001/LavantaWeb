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
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
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
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(kullanici);
            if (results.IsValid)
            {
                um.AddUserBl(kullanici);
                return RedirectToAction("Index");
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