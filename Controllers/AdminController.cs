using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

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
            //string passwordHash = AccountController.MD5Hash(admin.AdminPassword.ToString());
            string passwordHash = MD5Hash(admin.AdminPassword.ToString());
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
        public static string MD5Hash(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(text);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}