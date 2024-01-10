using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AydinogluLavender.Controllers
{
    [Authorize]//Yetkilendirme
    public class ShoppingCartController : Controller
    {
        ShoppingCartManager scm = new ShoppingCartManager(new EfShoppingCartDal());
        UserManager um = new UserManager(new EfUserDal());
        OrderManager om = new OrderManager(new EfOrderDal());
        OrderDetailManager odm = new OrderDetailManager(new EfOrderDetailDal());

        // GET: ShoppingCart
        public ActionResult Index()
        {
            if (Request.Cookies["AydinogluLavender"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            //var UserInfo = um.GetBySession(Session["UserMail"].ToString());
            var UserInfo = um.GetByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());
            int UserIdInfo = UserInfo.UserID;
            var cartlist = scm.GetUserList(UserIdInfo);
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
            if (Request.Cookies["AydinogluLavender"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            //var UserInfo = um.GetBySession(Session["UserMail"].ToString());
            var UserInfo = um.GetByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());
            cart.UserID = UserInfo.UserID;
            var CartInfo = scm.GetByID(cart.UserID, cart.ProductID);
            if (CartInfo == null)
            {
                scm.AddShoppingCartBl(cart);
            }
            else
            {
                CartInfo.ProductPiece = cart.ProductPiece + CartInfo.ProductPiece;
                scm.UpdateShoppingCartBl(CartInfo);
            }
            Session["statusAdd"] = "Basarili";
            int productid = cart.ProductID;
            string productdetails = "Details/" + productid;
            return RedirectToAction(productdetails, "Product");
        }
        public ActionResult DeleteCart(int id)
        {
            var cartinfo = scm.GetByID(id);
            scm.DeleteShoppingCartBl(cartinfo);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateCart(ShoppingCart shoppingCartInfo)
        {
            //var UserInfo = um.GetBySession(Session["UserMail"].ToString());
            var UserInfo = um.GetByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());
            shoppingCartInfo.UserID = UserInfo.UserID;
            scm.UpdateShoppingCartBl(shoppingCartInfo);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult OrderAdd()
        {
            //var UserValue = um.GetBySession(Session["UserMail"].ToString());//User id yi Sessiondan bulma
            var UserValue = um.GetByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());//User id yi Cookies den bulma
            var cartlist = scm.GetUserList(UserValue.UserID);//Sepeti çekme
            float OrderTotalPrice = 0; //Toplam fiyat için değer oluşturma
            DateTime datetime = DateTime.Now; // anlık tarihi çekme
            foreach (var cart in cartlist) //Sepet toplam tutarının hesaplanması
            {
                OrderTotalPrice = OrderTotalPrice + (cart.Product.ProductPrice * cart.ProductPiece);
            }

            Order order = new Order(); // Boş Sipariş oluşturularak içeriğinin doldurulması
            order.UserID = UserValue.UserID;
            order.OrderDateTime = datetime;
            order.OrderState = "Siparişiniz Onay Beklemektedir.";
            order.OrderPayType = "EFT/Havale";
            order.OrderPrice = OrderTotalPrice;
            order.OrderAddress = UserValue.UserCity + "/" + UserValue.UserDistrict + "/" + UserValue.UserAddress;
            order.OrderCargoPrice = "0";
            om.AddOrderBl(order); // Siparişin veritabanına eklenmesi

            var OrderValues = om.GetOrderUserList(UserValue.UserID); //Userın tüm siparişlerinin çekilmesi
            int orderid = 1;
            foreach (var item in OrderValues)//Son siparişe kadar Orderidnin sürekli değişmesi
            {
                orderid = item.OrderID;
            }
            OrderDetail orderDetailValue = new OrderDetail(); // Boş OrderDetail oluşturma
            orderDetailValue.OrderID = orderid; // Veritabanına eklenen siparişin idsinin çekilmesi


            foreach (var cart in cartlist) //Sepetin Sipariş detayına dönüştürülmesi
            {
                orderDetailValue.ProductID = cart.ProductID;
                orderDetailValue.ProductPiece = cart.ProductPiece;
                orderDetailValue.ProductUnitPrice = cart.Product.ProductPrice;
                odm.AddorderDetailBl(orderDetailValue);
                scm.DeleteShoppingCartBl(cart); // OrderDetail e aktarılan sepetin silinmesi
            }
            return RedirectToAction("Order", "Account");
        }
        public ActionResult Payment()
        {
            return View();
        }
    }
}