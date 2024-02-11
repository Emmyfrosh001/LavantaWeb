using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AydinogluLavender.Controllers
{
    public class AccountController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        OrderManager om = new OrderManager(new EfOrderDal());
        OrderDetailManager odm = new OrderDetailManager(new EfOrderDetailDal());
        // GET: Account
        [Authorize]//Yetkilendirme
        public ActionResult Index()
        {
            //if (Session["UserMail"]==null)
            //{
            //    return RedirectToAction("Login");
            //}

            //--------
            //Böyle bir cookie mevcut mu kontrol ediyoruz
            string name = "AydinogluLavender";
            if (Request.Cookies.AllKeys.Contains(name))
            {
                //böyle bir cookie varsa bize geri değeri döndürsün
                return View();
            }
            //return null;
            //----------------

            //if (Request.Cookies["AydinogluLavender"] == null)
            //{
            //    return RedirectToAction("Login");
            //}
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User login)
        {

            Context c = new Context();
            var userlogininfo = c.Users.FirstOrDefault(x => x.UserMail == login.UserMail && x.UserPassword == login.UserPassword && x.UserStatus==true);
            if (userlogininfo != null)
            {

                HttpCookie AydinogluLavenderCookie = new HttpCookie("AydinogluLavender");
                AydinogluLavenderCookie["UserMail"] = userlogininfo.UserMail;
                AydinogluLavenderCookie.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(AydinogluLavenderCookie);

                FormsAuthentication.SetAuthCookie(userlogininfo.UserMail, true);
                Session["UserMail"] = userlogininfo.UserMail;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [Authorize]//Yetkilendirme
        public ActionResult Order()
        {
            //int UserValue = um.FindUserIdBySession(Session["UserMail"].ToString());//User id yi Sessiondan bulma
            int UserValue = um.FindUserIdByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());//User id yi Cookieden bulma
            var OrderValues = om.GetOrderUserList(UserValue); //Userın tüm siparişlerinin çekilmesi
            return View(OrderValues);
        }
        [Authorize]//Yetkilendirme
        public ActionResult OrderDetail(int id)
        {
            int UserValue = um.FindUserIdByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());//User id yi Cookieden bulma
            var OrderValues = om.GetOrderUserList(UserValue);
            ViewBag.OrderInfo = null;
            foreach (var item in OrderValues)
            {
                if (item.OrderID == id)
                {
                    ViewBag.OrderInfo= item;
                    var OrderDetailValues = odm.GetOrderDetailList(id); //Userın tüm siparişlerinin çekilmesi
                    return View(OrderDetailValues);
                }
            }
            return RedirectToAction("Logout");
        }

        public ActionResult Logout()
        {
            HttpCookie AydinogluLavenderCookie = new HttpCookie("AydinogluLavender");
            AydinogluLavenderCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(AydinogluLavenderCookie);

            FormsAuthentication.SignOut();
            Session["UserMail"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}