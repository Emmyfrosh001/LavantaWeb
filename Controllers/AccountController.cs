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
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            if (Session["UserMail"]==null)
            {
                return RedirectToAction("Login");
            }
            return View();
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
            var userlogininfo = c.Users.FirstOrDefault(x => x.UserMail == login.UserMail && x.UserPassword == login.UserPassword);
            if (userlogininfo != null)
            {

                Session["UserMail"] = userlogininfo.UserMail;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserMail"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}