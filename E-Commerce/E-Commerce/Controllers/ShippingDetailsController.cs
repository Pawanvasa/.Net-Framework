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
    public class ShippingDetailsController : Controller
    {
        ShippingDbAccess shipping;
        public ShippingDetailsController()
        {
            shipping = new ShippingDbAccess();

        }
        // GET: ShippingDetails
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetAddresses(int? ship)
        {
            try
            {
                int UserId = Convert.ToInt32(Session["UserId"]);
                if(ship != 0 && ship!=null)
                {
                    Session["ProductId"] = ship;
                }
                if (UserId == 0)
                {
                    return RedirectToAction("Login", "Account");
                }
                var address = await shipping.getAddress(UserId);
                return View(address);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public ActionResult Create()
        {
            try
            {
                var UserId = Convert.ToInt32(Session["UserId"]);

                if (UserId == 0)
                {
                    return RedirectToAction("Login", "Account");
                }
                var shipping = new Shipping();
                return View(shipping);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Shipping details)
        {
            try
            {
                details.UserId = Convert.ToInt32(Session["UserId"]);
                var res = await shipping.CreateAddress(details);
                return RedirectToAction("GetAddresses");
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var response = await shipping.getAddressById(id);
                return View(response.First());
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Shipping details)
        {
            try
            {
                var respose = await shipping.Update(id, details);
                return RedirectToAction("GetAddresses");
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
    }

}