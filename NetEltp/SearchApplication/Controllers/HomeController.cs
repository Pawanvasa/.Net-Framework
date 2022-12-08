using Microsoft.AspNetCore.Mvc;
using SearchApplication.Models;
using System.Diagnostics;

namespace SearchApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        CRUDContext context= new CRUDContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult search(string SearchCriteria)
        {
            var result = context.Products.ToList();
            if (SearchCriteria != null)
            {
                var keyWords = SearchCriteria.Split(' ');
                result = new List<Product>();
                foreach (var keyWord in keyWords)
                {
                    var records = (from prod in context.Products
                                   select prod).Where(c => c.Description.Contains(keyWord)
                                   || c.ProductName.Contains(keyWord)
                                   || c.Manufature.Contains(keyWord)
                                   || c.Price.ToString().Equals(keyWord)
                                   || c.Seller.Contains(keyWord)).ToList();
                    result!.AddRange(records);

                }
                result = result.Distinct().ToList();
                ViewBag.Records = result;
            }
                ViewBag.Records = result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}