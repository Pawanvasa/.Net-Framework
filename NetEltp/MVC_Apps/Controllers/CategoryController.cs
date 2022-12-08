using Microsoft.AspNetCore.Mvc;
using Coditas.ECom.Repositories;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.AspNetCore.Identity;
using MVC_Apps.CustomSessionExtensions;
using Microsoft.AspNetCore.Authorization;

namespace MVC_Apps.Controllers
{
    //[Authorize]
    public class CategoryController : Controller
    {
        IDBRepository<Category, int> dBRepository;
        public CategoryController(IDBRepository<Category, int> dBRepository)
        {
            this.dBRepository = dBRepository;
        }

        [Authorize(Policy = "ReadPolicy")]
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.Clear();
            var result = await dBRepository.GetAsync();
            return View(result);
        }
        public async Task<IActionResult> IndexTagHelper()
        
        {
            try
            {
                var records = await dBRepository.GetAsync();

                return View(records);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Authorize(Policy = "CreatePolicy")]
        public IActionResult Create()
        {
            var cat = HttpContext.Session.GetObject<Category>("enterDetails");
            if (cat != null)
            {
                if (cat.BasePrice < 0)
                {
                    ViewBag.Message = "Invalid Price";
                }
            }
            return View(cat);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.BasePrice < 0)
                {
                    HttpContext.Session.SetObject<Category>("enterDetails", category);
                    throw new Exception("Base Price Connot be Negative");
                }
                var result = await dBRepository.CreateAsync(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        [Authorize(Policy = "EditPolicy")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await dBRepository.GetByIdAsync(id);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {

            var respose = await dBRepository.UpdateAsync(id, category);
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "DeletePolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            var respose = await dBRepository.GetByIdAsync(id);
            return View(respose);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var respose = await dBRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var respons = await dBRepository.GetByIdAsync(id);
            return View(respons);
        }

        public async Task<IActionResult> ShowDetails(int id)
        {
            // Save the 'id' isn Session State
            HttpContext.Session.SetInt32("CategoryId", id);

            // Save Entity Object in Session
            var category = await dBRepository.GetByIdAsync(id);
            HttpContext.Session.SetObject<Category>("Cat", category);

            // Redirect to the ProductController and its Index Method
            return RedirectToAction("Index", "Product");

        }
    }
}
