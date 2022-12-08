using E_Commerce.Models;
using E_Commerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace E_Commerce.Controllers
{
    public class SubCategoryController : Controller
    {
        SubcategoryDBAccess service;
        CategoryDbAccess categoryDbAccess;
        public SubCategoryController()
        {
            categoryDbAccess = new CategoryDbAccess();
            service = new SubcategoryDBAccess();
        }
        // GET: SubCategory
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Get()
        {
            try
            {
                var subCategories = await service.Get();
                return View(subCategories);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> GetById()
        {
            try
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var subCategorie = await service.GetById(userId);
                return View(subCategorie);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> Create()
        {
            try
            {
                IEnumerable<SelectListItem> cats = (await categoryDbAccess.GetAllCategories()).Select(n =>
                   new SelectListItem
                   {
                       Value = n.categoryid.ToString(),
                       Text = n.categoryName
                   });
                ViewBag.categories = cats;
                var subCategorie = new subCategory();
                return View(subCategorie);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(subCategory categorie)
        {
            try
            {
                var result = service.Create(categorie);
                return RedirectToAction("Get");
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var response = await service.GetById(id);
                return View(response);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, subCategory categorie)
        {

            try
            {
                var respose = await service.Update(id, categorie);
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
    }
}