using E_Commerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class OrderController : Controller
    {
        OrderDbAccess service;
        public OrderController()
        {
            service = new OrderDbAccess();
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Get()
        {
            try
            {
                var orders = await service.Get();
                return View(orders);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> CancelOrder(int id)
        {
            try
            {
                var res = await service.Cancel(id);
                return RedirectToAction("GetById");
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> GetById()
        {
            try
            {
                int id = Convert.ToInt32(Session["UserId"]);
                var orders = await service.GetById(id);
                return View(orders);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

    }
}