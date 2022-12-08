using E_Commerce.Models;
using E_Commerce.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        ProductDBAccess service;
        SubcategoryDBAccess subcategoryDBAccess;
        public ProductController()
        {
            service = new ProductDBAccess();
            subcategoryDBAccess = new SubcategoryDBAccess();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Get()
        {

            try
            {
                var categories = await service.Get();
                return View(categories);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> Create(string path)
        {
            try
            {
                var product = new Product();
                IEnumerable<SelectListItem> subCats = (await subcategoryDBAccess.Get()).Select(n =>
                            new SelectListItem
                            {
                                Value = n.SubCategoryId.ToString(),
                                Text = n.SubcategoryName
                            }).ToList();
                ViewBag.SubCategories = subCats;

                if (path != null)
                {
                    string[] saparater = { "\\E-Commerce" };
                    string[] actualpath = path.Split(saparater, StringSplitOptions.None);
                    product.ProductImage = "~" + actualpath[actualpath.Length - 1];
                }
                return View(product);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }

        }

        [HttpPost]
        public ActionResult Create(Product product)
        {

            try
            {
                var result = service.Create(product);
                return RedirectToAction("Get");
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                IEnumerable<SelectListItem> subCats = (await subcategoryDBAccess.Get()).Select(n =>
                               new SelectListItem
                               {
                                   Value = n.SubCategoryId.ToString(),
                                   Text = n.SubcategoryName
                               }).ToList();
                ViewBag.SubCategories = subCats;

                var response = await service.GetById(id);
                return View(response);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Product product)
        {

            try
            {
                var respose = await service.Update(id, product);
                return RedirectToAction("Get");
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }

        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var respose = await service.GetById(id);
                return View(respose);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            try
            {
                var respose = await service.Delete(id);
                return RedirectToAction("Get");
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> GetProductById(int id)
        {
            try
            {
                var product = await service.GetById(id);
                return View(product);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> SearchProducts(string searchTxt)
        {
            try
            {
                var products = await service.searchProducts(searchTxt);
                if (products.Count() > 0)
                {
                    Session["Products"] = products;
                    return RedirectToAction("Categoryprods", "Home",new { categoryId =0});
                }
                return RedirectToAction("Categoryprods", "Home", new { categoryId = 0 });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> GetProdsOnCat(int categoryId)
        {
            try
            {
                var products = await service.getProdsBycategoryId(categoryId);
                Session["catProducts"] = products;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }


        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            try
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = "C:\\DotNet\\E-Commerce\\E-Commerce\\img\\Products\\" + _FileName;
                ViewBag.Path = _path;
                file.SaveAs(_path);
                return RedirectToAction("Create", new { path = _path });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
    }
}