using E_Commerce.Models;
using E_Commerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        ProductDBAccess productDBAccess;
        CategoryDbAccess categoryDBAccess;
        public HomeController()
        {
            productDBAccess = new ProductDBAccess();
            categoryDBAccess = new CategoryDbAccess();
        }
        public async Task<ActionResult> Index(IEnumerable<Product> prod)
        {
            try
            {
                var product = (List<Product>)Session["catProducts"];
                if (product != null && product.Count > 0)
                {
                    //Session.Clear();
                    Session.Remove("catProducts");
                    return View(product);
                }
               
                Session["Cats"] = await categoryDBAccess.GetAllCategories();
                ViewBag.Rating = new Random().Next(2, 5);
                var products = await productDBAccess.Get();
                return View(products);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> Categoryprods(int categoryId)
        {
            try
            {
                var prods = Session["Products"];
                if (prods != null)
                {
                    //Session.Clear();
                    Session.Remove("Products");
                    return View(prods);
                }
                var products = await productDBAccess.getProdsBycategoryId(categoryId);
                Session["catProducts"] = products;
                return View(products);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public ActionResult ErrorPage()
        {
            return View();
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
    }
}