using Coditas.ECom.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Apps.Models;
using System.Diagnostics;

namespace MVC_Apps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IDBRepository<Category, int> CatServ;
        IDBRepository<Product, int> ProdServ;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        public HomeController(ILogger<HomeController> logger, IDBRepository<Category, int> catServ, IDBRepository<Product, int> prodServ, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager; 
            _logger = logger;
            CatServ = catServ;
            ProdServ = prodServ;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetById(int id)
        {
            CatAndProd catAndProd = new CatAndProd();
            catAndProd.Category = await CatServ.GetAsync();
            catAndProd.Product = (await ProdServ.GetAsync()).Where(prod => prod.CategoryId == id);
            return View(catAndProd);
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