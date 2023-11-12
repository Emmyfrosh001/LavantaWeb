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
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult results = categoryvalidator.Validate(ctg);
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
        public ActionResult DeleteCategory(int id)
        {
            //var categoryvelue=cm.GetByID(id);
            //cm.DeleteCategoryBl(categoryvelue);
            var CategoryValue = cm.GetByID(id);
            if (CategoryValue.CategoryStatus == true)
            {
                CategoryValue.CategoryStatus = false;
            }
            else
            {
                CategoryValue.CategoryStatus = true;
            }
            cm.UpdateCategoryBl(CategoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = cm.GetByID(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.UpdateCategoryBl(category);
            return RedirectToAction("Index");
        }
    }
}