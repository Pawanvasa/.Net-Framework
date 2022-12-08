using E_Commerce.Models;
using E_Commerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace E_Commerce.Controllers
{
    public class AdminController : Controller
    {
        UserDBAccessService userDBAccessService;
        public AdminController()
        {
            userDBAccessService=new UserDBAccessService();
        }
        // GET: Admin
        public async Task<ActionResult> Index()
        {
            try
            {
                var users = await userDBAccessService.Get();
                return RedirectToAction("Get","User");
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

    }
}