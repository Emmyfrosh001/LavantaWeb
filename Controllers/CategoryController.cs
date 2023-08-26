using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AydinogluLavender.Controllers
{
    public class CategoryController : Controller
    {
        categorymanager
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
    }
}