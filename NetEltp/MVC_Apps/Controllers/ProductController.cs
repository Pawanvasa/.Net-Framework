using Coditas.ECom.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Apps.CustomSessionExtensions;
namespace MVC_Apps.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IDBRepository<Product, int> dBRepository;
        IDBRepository<Category, int> catRepo;
        public ProductController(IDBRepository<Product, int> dBRepository, IDBRepository<Category, int> catRepo)
        {
            this.dBRepository = dBRepository;
            this.catRepo = catRepo;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> records;
            // REad CategoryId from Session
            int CategoryId = Convert.ToInt32(HttpContext.Session.GetInt32("CategoryId"));

            var cat = HttpContext.Session.GetObject<Category>("Cat");

            if (CategoryId == 0)
            {
                records = await dBRepository.GetAsync();
            }
            else
            {
                records = (await dBRepository.GetAsync()).Where(p => p.CategoryId == CategoryId).ToList();
            }
            return View(records);
        }

        public async Task<IActionResult> IndexTagHelper()
        {
            try
            {
                var records = await dBRepository.GetAsync();

                return View(records);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Create()
        {
            List<Category> categories = (await catRepo.GetAsync()).ToList();

            List<SelectListItem> categoryItem = new List<SelectListItem>();
            // Add Data from "categories" to "categoryItem"
            foreach (var cat in categories)
            {
                categoryItem.Add(new SelectListItem(cat.CategoryName, cat.CategoryId.ToString()));
            }
            // USe ViewBag to pass Data to UI
            ViewBag.Categories = categoryItem;
            var Product = new Product();
            return View(Product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await dBRepository.CreateAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await dBRepository.GetByIdAsync(id);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {

            var respose = await dBRepository.UpdateAsync(id, product);
            return RedirectToAction("Index");

        }

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
    }
}
