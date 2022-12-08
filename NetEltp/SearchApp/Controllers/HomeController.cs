using Microsoft.AspNetCore.Mvc;
using SearchApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using SearchApp.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace SearchApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        eShoppingContext _crudContext;
        public HomeController(ILogger<HomeController> logger)
        {
            _crudContext = new eShoppingContext();
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> search()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> searchResult(string SearchCriteria)
        {
            var result= _crudContext.Products.ToList();
            if (SearchCriteria != null)
             {
                 var keyWords = SearchCriteria.Split(' ');
                 foreach (var keyWord in keyWords)
                 {
                    result = (from prod in _crudContext.Products
                              select prod).Where(
                                 c => c.Description.Contains(keyWord) 
                              || c.ProductName.Contains(keyWord)
                              || c.Manufacturer.Contains(keyWord)).ToList();
                 }
                 return View(result);
             }
           

            return View(result);
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