using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AydinogluLavender.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            List<Category> categorylist = cm.GetAktifAllList();
            ViewBag.categoriler = categorylist;
            var productlist=pm.GetAktifList();
            return View(productlist);
        }

        public ActionResult Details(int id)
        {
            var productdetail = pm.GetByID(id);
            return View(productdetail);
        }
    }
}