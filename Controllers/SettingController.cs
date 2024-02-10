using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AydinogluLavender.Controllers
{
    public class SettingController : Controller
    {
        SettingManager sm = new SettingManager(new EfSettingDal());
        // GET: Setting
        public ActionResult Index()
        {
            return View(sm.GetSetting());
        }
        [HttpGet]
        public ActionResult EditSetting()
        {
            return View(sm.GetSetting());
        }

        [HttpPost]
        public ActionResult EditSetting(Setting setting)
        {
            sm.UpdateSettingBl(setting);
            return RedirectToAction("Index");
        }
    }
}