using E_Commerce.Models.EntityClasses;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using E_Commerce.Services;

namespace E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryDbAccess service;
        public CategoryController()
        {
            service = new CategoryDbAccess();
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Get()
        {
            try
            {
                var categories = await service.GetAllCategories();
                return View(categories);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> GetById()
        {
            try
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var categories = await service.GetById(userId);
                return View(categories);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public ActionResult Create()
        {
            try
            {
                var categorie = new category();
                return View(categorie);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        [HttpPost]
        public ActionResult Create(category categorie)
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
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, category categorie)
        {

            try
            {
                var respose = await service.Update(id, categorie);
                return RedirectToAction("Get");
            }
            catch (Exception )
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
                return RedirectToAction("Get", "Category");
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

    }
}