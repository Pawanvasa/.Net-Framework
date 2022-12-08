using ClientNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MVCClient_OASApp.Models;
using System.Diagnostics;

namespace MVCClient_OASApp.Controllers
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
            return View(res);
        }

        public async Task<IActionResult> create()
        {
            var cat = new ClientNS.Category();
            ViewBag.categori=cat;   
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create(ClientNS.Category category)
        {
            var cat = await proxy.CreatecategoryAsync(category);
            ViewBag.Categories = cat;
            return RedirectToAction("Index");
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