using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace AydinogluLavender.Controllers
{
    public class RegisterController : Controller
    {

        UserManager um = new UserManager(new EfUserDal());
        UserValidator userValidator = new UserValidator();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User kullanici)
        {
            if(TestEmailRegex(kullanici.UserMail))
            {

                if (um.GetUserMail(kullanici.UserMail) == null)
                {
                    kullanici.UserStatus = true;
                    kullanici.UserPassword = MD5Hash(kullanici.UserPassword);
                    ValidationResult results = userValidator.Validate(kullanici);
                    if (results.IsValid)
                    {
                        um.AddUserBl(kullanici);
                        Context c = new Context();
                        string Encrypted = MD5Hash(DateTime.Now.ToString());

                        HttpCookie AydinogluLavenderCookie = new HttpCookie("AydinogluLavender");
                        AydinogluLavenderCookie["UserMail"] = kullanici.UserMail;
                        AydinogluLavenderCookie.Expires = DateTime.Now.AddDays(10);
                        Response.Cookies.Add(AydinogluLavenderCookie);

                        HttpCookie LoginCookie = new HttpCookie("LoginData");
                        LoginCookie.Values.Add("Data", Encrypted);
                        LoginCookie.Expires = DateTime.Now.AddDays(10);
                        Response.Cookies.Add(LoginCookie);

                        FormsAuthentication.SetAuthCookie(kullanici.UserMail, true);
                        Session["UserMail"] = kullanici.UserMail;

                        kullanici.LoginInfo = Encrypted;
                        um.UpdateUserBl(kullanici);

                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        foreach (var item in results.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                        }
                    }

                }
                else
                {

                    Session["MailInfo"] = "Kayitli";
                }
            }
            else
            {
                Session["MailInfo"] = "Gecersiz";
            }
            return View();
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
        public bool TestEmailRegex(string emailAddress)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
            + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);
            bool isStrictMatch = reStrict.IsMatch(emailAddress);
            return isStrictMatch;

        }
    }
}