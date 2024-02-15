using AydinogluLavender.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
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
                var UserValue = um.GetByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());
                return View(UserValue);
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
            string passwordHash = MD5Hash(login.UserPassword.ToString());
            var userlogininfo = c.Users.FirstOrDefault(x => x.UserMail == login.UserMail && x.UserPassword == passwordHash && x.UserStatus == true);
            if (userlogininfo != null)
            {
                string Encrypted = MD5Hash(DateTime.Now.ToString());

                HttpCookie AydinogluLavenderCookie = new HttpCookie("AydinogluLavender");
                AydinogluLavenderCookie["UserMail"] = userlogininfo.UserMail;
                AydinogluLavenderCookie.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(AydinogluLavenderCookie);

                HttpCookie LoginCookie = new HttpCookie("LoginData");
                LoginCookie.Values.Add("Data", Encrypted);
                LoginCookie.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(LoginCookie);

                FormsAuthentication.SetAuthCookie(userlogininfo.UserMail, true);
                Session["UserMail"] = userlogininfo.UserMail;

                userlogininfo.LoginInfo = Encrypted;
                um.UpdateUserBl(userlogininfo);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["Login"] = "Error";
                return RedirectToAction("Login");
            }
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


        [Authorize]//Yetkilendirme
        public ActionResult Order()
        {
            //int UserValue = um.FindUserIdBySession(Session["UserMail"].ToString());//User id yi Sessiondan bulma
            int UserValue = um.FindUserIdByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString(), Request.Cookies["LoginData"]?["Data"].ToString());//User id yi Cookieden bulma
            var OrderValues = om.GetOrderUserList(UserValue); //Userın tüm siparişlerinin çekilmesi
            return View(OrderValues);
        }
        [Authorize]//Yetkilendirme
        public ActionResult OrderDetail(int id)
        {
            int UserValue = um.FindUserIdByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString(), Request.Cookies["LoginData"]?["Data"].ToString());//User id yi Cookieden bulma
            var OrderValues = om.GetOrderUserList(UserValue);
            ViewBag.OrderInfo = null;
            foreach (var item in OrderValues)
            {
                if (item.OrderID == id)
                {
                    ViewBag.OrderInfo = item;
                    var OrderDetailValues = odm.GetOrderDetailList(id); //Userın tüm siparişlerinin çekilmesi
                    return View(OrderDetailValues);
                }
            }
            return RedirectToAction("Logout");
        }

        public ActionResult Logout()
        {
            var UserValue = um.GetByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());
            UserValue.LoginInfo = null;
            um.UpdateUserBl(UserValue);

            HttpCookie AydinogluLavenderCookie = new HttpCookie("AydinogluLavender");
            AydinogluLavenderCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(AydinogluLavenderCookie);

            HttpCookie LoginCookie = new HttpCookie("LoginData");
            //HttpContext.Response.Cookies.Set(LoginCookie);// Cookie'nin içini boşaltıyor
            LoginCookie.Expires = DateTime.Now.AddDays(-1d);// Cookie'nin süresini geçmiş göstererek ortadan kaldırıyor
            Response.Cookies.Add(LoginCookie);

            FormsAuthentication.SignOut();
            Session["UserMail"] = null;
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            string name = "AydinogluLavender";
            if (Request.Cookies.AllKeys.Contains(name))
            {
                int UseridValue = um.FindUserIdByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString(), Request.Cookies["LoginData"]?["Data"].ToString());//User id yi Cookieden bulma
                if (UseridValue >= 0)
                {
                    var UserValue = um.GetByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());

                    UserValue.UserName = user.UserName;
                    UserValue.UserSurname = user.UserSurname;
                    UserValue.UserPhoneNumber = user.UserPhoneNumber;
                    UserValue.UserCity = user.UserCity;
                    UserValue.UserDistrict = user.UserDistrict;
                    UserValue.UserAddress = user.UserAddress;

                    UserValidator userValidator = new UserValidator();
                    ValidationResult results = userValidator.Validate(user);
                    if (results.IsValid)
                    {
                        um.UpdateUserBl(UserValue);
                        return RedirectToAction("/Index", "Account");
                    }
                    else
                    {
                        foreach (var item in results.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                        }
                        return View();
                    }
                }
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult PasswordChange (Password data)
        {
            
            if (data.passwordnew == data.passwordnewagain)
            {
                int UseridValue = um.FindUserIdByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString(), Request.Cookies["LoginData"]?["Data"].ToString());//User id yi Cookieden bulma
                if (UseridValue >= 0)
                {
                    data.password=MD5Hash(data.password);//kullanıcıdan alınan parola Encrypted oldu.
                    var UserValue = um.GetByCookies(Request.Cookies["AydinogluLavender"]?["UserMail"].ToString());
                    if (data.password == UserValue.UserPassword)// Veri tabanındaki Encrypted şifre ile girilen parola karşılaştırıldı
                    {
                        UserValue.UserPassword = MD5Hash(data.passwordnew);// Yeni parola Encrypt edilerek kullanıcı verisideğiştirildi.
                        um.UpdateUserBl(UserValue); //Değiştirilen şifre veritabanında güncellendi
                        Session["PasswordAlert"] = "success";
                    }
                    else
                    {
                        Session["PasswordAlert"] = "PasswordOldError";
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                Session["PasswordAlert"] = "PasswordNewDifferent";
            }
            return RedirectToAction("/Index");
        }

    }
}