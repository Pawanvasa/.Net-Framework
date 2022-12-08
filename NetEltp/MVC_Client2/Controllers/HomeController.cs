using Microsoft.AspNetCore.Mvc;
using MVC_Client2.Models;
using System.Diagnostics;
using ClientNS;
using Microsoft.AspNetCore.SignalR;

namespace MVC_Client2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = null!;
        string baseUrl = string.Empty;
        ClientProxy proxy = null!;
        public HomeController(ILogger<HomeController> logger)
        {
            baseUrl = "https://localhost:7054/";
            client = new HttpClient();
            proxy = new ClientProxy(baseUrl, client);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> GetData()
        {
            var result = await proxy.GetDetailsAsync();
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