using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AydinogluLavender.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["AdminName"] ==null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            Context c = new Context();
            var adminlogininfo=c.Admins.FirstOrDefault(x=>x.AdminName==admin.AdminName && x.AdminPassword==admin.AdminPassword);
            if (adminlogininfo!=null) 
            {
                HttpCookie AydinogluLavenderCookie = new HttpCookie("AydinogluLavenderAdmin");
                AydinogluLavenderCookie["AdminName"] = adminlogininfo.AdminName;
                AydinogluLavenderCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(AydinogluLavenderCookie);


                FormsAuthentication.SetAuthCookie(adminlogininfo.AdminName, true);
                Session["AdminName"] = adminlogininfo.AdminName;
                //return RedirectToAction("Index", "AdminCategory");
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {

            HttpCookie AydinogluLavenderCookie = new HttpCookie("AydinogluLavenderAdmin");
            AydinogluLavenderCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(AydinogluLavenderCookie);

            FormsAuthentication.SignOut();
            Session["AdminName"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}