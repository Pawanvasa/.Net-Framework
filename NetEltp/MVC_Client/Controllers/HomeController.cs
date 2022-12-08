using ClientNS;
using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;
using System.Diagnostics;

namespace MVC_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = null!;
        string baseUrl = string.Empty;
        Client_Proxy proxy = null!;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            baseUrl = "https://localhost:7259/";
            client = new HttpClient();
            proxy = new Client_Proxy(baseUrl, client);
        }

        public async Task<IActionResult> Index()
        {
            var res = await proxy.GetcategotiesAsync();
            ViewBag.result = res;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> getProducts(Category cat)
        {
            var products =await proxy.GetProdByCatIdAsync(cat.CategoryId);
            ViewBag.products=products;
            return View();// RedirectToAction("Index", new {id=cat.CategoryId }); 
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