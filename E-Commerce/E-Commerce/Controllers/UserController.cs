using E_Commerce.Models;
using E_Commerce.Models.EntityClasses;
using E_Commerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class UserController : Controller
    {
        UserDBAccessService service;
        public UserController()
        {
            service = new UserDBAccessService();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Get()
        {
            try
            {
                var Users = await service.Get();
                return View(Users);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> GetById()
        {
            try
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var user = await service.GetById(userId);
                return View(user);
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
                var user = new UserTable();
                return View(user);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        [HttpPost]
        public ActionResult Create(UserEntity user)
        {
            try
            {
                var result = service.Create(user);
                return RedirectToAction("Get");
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var response = await service.GetById(id);
                return View(response);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, UserTable user)
        {

            try
            {
                var userid = Convert.ToInt32(Session["UserId"]);
                user.UserId = userid;
                var respose = await service.Update(id, user);
                if (userid == 5)
                {
                    return RedirectToAction("Get");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }

        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var respose = await service.GetById(id);
                return View(respose);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            try
            {
                var respose = await service.Delete(id);
                return RedirectToAction("Get", "User");
            }   
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

    }
}