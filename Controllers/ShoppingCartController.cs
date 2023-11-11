using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AydinogluLavender.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCartManager scm = new ShoppingCartManager(new EfShoppingCartDal());
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddCart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCart(ShoppingCart cart)
        {
            //scm.AddShoppingCartBl(cart);
            int productid = cart.ProductID;
            string productdetails = "details/"+productid;
            return RedirectToAction(productdetails, "Product");
        }
    }
}