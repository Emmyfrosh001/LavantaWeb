using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
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
        public ActionResult Index()
        {
            var productlist=pm.GetAllList();
            return View(productlist);
        }
    }
}