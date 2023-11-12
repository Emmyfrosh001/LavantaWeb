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
        [Authorize]
        public ActionResult Index()
        {
            if (Session["AdminName"] ==null)
            {
                return RedirectToAction("Login", "Home");
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
                FormsAuthentication.SetAuthCookie(adminlogininfo.AdminName, false);
                Session["AdminName"] = adminlogininfo.AdminName;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserMail"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}