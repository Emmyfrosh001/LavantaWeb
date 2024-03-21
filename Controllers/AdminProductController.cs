using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AydinogluLavender.Controllers
{
    [Authorize(Roles = "AdmAL")]//Aouhorize komutunu kontroller seviyesine çıkarma
    public class AdminProductController : Controller
    {
        // GET: AdminProduct

        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var productlist = pm.GetAllList();
            return View(productlist);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {

            List<SelectListItem> categorylist = (from x in cm.GetAktifAllList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.categoriler = categorylist;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            ProductValidator productvalidator = new ProductValidator();
            ValidationResult results = productvalidator.Validate(product);
            if (results.IsValid)
            {
                pm.AddProductBl(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {

            List<SelectListItem> categorylist = (from x in cm.GetAktifAllList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.categoriler = categorylist;
            var Product = pm.GetByID(id);
            return View(Product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            pm.UpdateProductBl(product);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ProductImage1Edit(Product product)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/product/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                product.ProductImage1 = "product/" + dosyaadi + uzanti;
            }
            var data = pm.GetByID(product.ProductID);
            data.ProductImage1 = product.ProductImage1;
            pm.UpdateProductBl(data);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ProductImage2Edit(Product product)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/product/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                product.ProductImage2 = "product/" + dosyaadi + uzanti;
            }
            var data = pm.GetByID(product.ProductID);
            data.ProductImage2 = product.ProductImage2;
            pm.UpdateProductBl(data);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ProductImage3Edit(Product product)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/product/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                product.ProductImage3 = "product/" + dosyaadi + uzanti;
            }
            var data = pm.GetByID(product.ProductID);
            data.ProductImage3 = product.ProductImage3;
            pm.UpdateProductBl(data);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteProduct(int id)
        {
            var ProductValue = pm.GetByID(id);
            if (ProductValue.ProductStatus == true)
            {
                ProductValue.ProductStatus = false;
            }
            else
            {
                ProductValue.ProductStatus = true;
            }
            pm.UpdateProductBl(ProductValue);
            return RedirectToAction("Index");
        }
    }
}