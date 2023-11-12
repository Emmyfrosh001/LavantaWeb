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
        UserManager um=new UserManager(new EfUserDal());
        // GET: ShoppingCart
        public ActionResult Index()
        {
            if (Session["UserMail"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var UserInfo = um.GetBySession(Session["UserMail"].ToString());
            int UserIdInfo = UserInfo.UserID;
            var cartlist=scm.GetUserList(UserIdInfo);
            return View(cartlist);
        }
        [HttpGet]
        public ActionResult AddCart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCart(ShoppingCart cart)
        {
            if (Session["UserMail"] == null) 
            {
                return RedirectToAction("Login", "Account");
            }
            var UserInfo = um.GetBySession(Session["UserMail"].ToString());
            cart.UserID = UserInfo.UserID;
            var CartInfo=scm.GetByID(cart.UserID,cart.ProductID);
            if(CartInfo == null) 
            {
                scm.AddShoppingCartBl(cart);
            }
            else
            {
                CartInfo.ProductPiece=cart.ProductPiece+CartInfo.ProductPiece;
                scm.UpdateShoppingCartBl(CartInfo);
            }

            int productid = cart.ProductID;
            string productdetails = "details/"+productid;
            return RedirectToAction(productdetails, "Product");
        }
        public ActionResult DeleteCart(int id)
        {
            var cartinfo = scm.GetByID(id);
            scm.DeleteShoppingCartBl(cartinfo);
            return RedirectToAction("Index");
        }
        public ActionResult Trade()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateCart(ShoppingCart shoppingCartInfo)
        {
            var UserInfo = um.GetBySession(Session["UserMail"].ToString());
            shoppingCartInfo.UserID = UserInfo.UserID;
            scm.UpdateShoppingCartBl(shoppingCartInfo);
            return RedirectToAction("Index");
        }
    }
}