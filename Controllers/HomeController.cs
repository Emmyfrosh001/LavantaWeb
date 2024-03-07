using AydinogluLavender.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AydinogluLavender.Controllers
{
    public class HomeController : Controller
    {

        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        ContactManager ctm=new ContactManager(new EfContactDal());
        public ActionResult Index()
        {
            //List<SelectListItem> categorylist = (from x in cm.GetAktifAllList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            List<Category> categorylist = cm.GetAktifAllList();
            ViewBag.categoriler = categorylist;
            ViewBag.HomeIndex = true;
            var productlist = pm.GetAktifList();
            return View(productlist);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult ContactMessage(Contact parametre) 
        {
            ctm.AddContactBl(parametre);
            Session["statusAdd"] = "Basarili";
            return RedirectToAction("Contact", "Home");
        }
        Context c = new Context();
        //DbAydinogluLavenderEntities aldb = new DbAydinogluLavenderEntities();
        CityDistrict cd = new CityDistrict();
        public ActionResult Test()
        {

            //cd.Cities = new SelectList(aldb.Cities, "CityID", "CityName");
            //cd.Cities = new SelectList(aldb.Districts, "DistrictID", "DistrictName", "CityID");

            cd.Cities = new SelectList(c.Cities, "CityID", "CityName");
            cd.Districts = new SelectList(c.Districts, "DistrictID", "DistrictName");
            return View(cd);
        }

        public ActionResult Test2()
        {

            //cd.Cities = new SelectList(aldb.Cities, "CityID", "CityName");
            //cd.Cities = new SelectList(aldb.Districts, "DistrictID", "DistrictName", "CityID");

            //cd.Cities = new SelectList(c.Cities, "CityID", "CityName");
            //cd.Districts = new SelectList(c.Districts, "DistrictID", "DistrictName");
            //return View(cd);
            ViewBag.Cities = new SelectList(c.Cities, "CityID", "CityName").ToList();
            ViewBag.Districts = new SelectList(c.Districts, "DistrictID", "DistrictName").ToList();
            return View();
        }

        public JsonResult GetDistrict(int p)
        {
            var districts = (from x in c.Districts
                             join y in c.Cities on x.city.CityID equals y.CityID
                             where x.city.CityID == p
                             select new
                             {
                                 Text = x.DistrictName,
                                 Value = x.DistrictID.ToString()
                             }).ToList();

            return Json(districts, JsonRequestBehavior.AllowGet);
        }
    }
}