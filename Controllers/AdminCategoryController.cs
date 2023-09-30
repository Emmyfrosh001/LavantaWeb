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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory
        public ActionResult Index()
        {
            var categorylist = cm.GetAllList();
            return View(categorylist);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category ctg)
        {
            CategoryValidator categotyvalidator = new CategoryValidator();
            ValidationResult results = categotyvalidator.Validate(ctg);
            if (results.IsValid)
            {
                cm.AddCategoryBl(ctg);
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