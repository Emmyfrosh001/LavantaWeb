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
using System.Web.Routing;

namespace AydinogluLavender.Controllers
{
    [Authorize]//Yetkilendirme
    public class ShoppingCartController : Controller
    {
        ShoppingCartManager scm = new ShoppingCartManager(new EfShoppingCartDal());
        UserManager um = new UserManager(new EfUserDal());
        OrderManager om = new OrderManager(new EfOrderDal());
        OrderDetailManager odm = new OrderDetailManager(new EfOrderDetailDal());
        SettingManager sm=new SettingManager(new EfSettingDal());
        CityManager citym=new CityManager(new EfCityDal());
        DistrictManager distm=new DistrictManager(new EfDiscrictDal());

        // GET: ShoppingCart
        public ActionResult Index()
        {

            ViewBag.CargoPrice = sm.GetSetting().CargoPrice.ToString();
            if (Request.Cookies["AydinogluLavender"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            //var UserInfo = um.GetBySession(Session["UserMail"].ToString());
            int UserIdInfo = um.FindUserIdByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString(), Request.Cookies["LoginData"]?["Data"].ToString());//User id yi Cookieden bulma
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
            //var UserInfo = um.GetByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());
            int UserValue = um.FindUserIdByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString(), Request.Cookies["LoginData"]?["Data"].ToString());//User id yi Cookieden bulma
            cart.UserID = UserValue;
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
            int cargoprice = sm.GetSetting().CargoPrice;
            Order order = new Order(); // Boş Sipariş oluşturularak içeriğinin doldurulması
            order.UserID = UserValue.UserID;
            order.OrderDateTime = datetime;
            order.OrderState = "Siparişiniz Onay Beklemektedir.";
            order.OrderPayType = "EFT/Havale";
            order.OrderPrice = OrderTotalPrice+ cargoprice;
            order.OrderAddress = citym.GetByID((int)UserValue.UserCity).CityName + "/" + distm.GetByID((int)UserValue.UserDistrict).DistrictName + "/" + UserValue.UserAddress;
            order.OrderCargoPrice = cargoprice.ToString();
            om.AddOrderBl(order); // Siparişin veritabanına eklenmesi

            var OrderValues = om.GetOrderUserList(UserValue.UserID).FirstOrDefault(); //Userın tüm siparişlerinin çekilmesi
            int orderid = OrderValues.OrderID;
            //foreach (var item in OrderValues)//Son siparişe kadar Orderidnin sürekli değişmesi
            //{
            //    orderid = item.OrderID;
            //}
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
            //return RedirectToAction("Order", "Account");
            return RedirectToAction("OrderDetail", new RouteValueDictionary(new { controller = "Account", action = "OrderDetail", Id = orderid }));
        }
        public ActionResult Payment()
        {
            int total = sm.GetSetting().CargoPrice;
            if (Request.Cookies["AydinogluLavender"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            //var UserInfo = um.GetBySession(Session["UserMail"].ToString());
            int UserIdInfo = um.FindUserIdByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString(), Request.Cookies["LoginData"]?["Data"].ToString());//User id yi Cookieden bulma
            var cartlist = scm.GetUserList(UserIdInfo);
            foreach (var cart in cartlist)
            {
                total = total + (int)(cart.ProductPiece * cart.Product.ProductPrice);
            }
            ViewBag.Total = total;
            return View();
        }
    }
}