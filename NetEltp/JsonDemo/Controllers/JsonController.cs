using JsonDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonDemo.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public JsonResult Index()
        {
            bool isAdmin = false;
            string output = isAdmin ? "Welcome Admin" : "Welcome user";
            return Json(output,JsonRequestBehavior.AllowGet);
        }

        public List<Users> GetUsers()
        {
            List<Users> user = new List<Users>() 
            {
              new Users
              {
                  userId=1,
                  UserName="Pawan",
                  companyName="Coditas"
              },
              new Users
              {
                   userId=2,
                  UserName="Amar",
                  companyName="Apple"
              },
              new Users
              {
                   userId=3,
                  UserName="Bravo",
                  companyName="Amazon"
              }

            };
            return user;
        }

        public JsonResult userDetails()
        {
            try
            {
                var users = GetUsers();
                return Json(users, JsonRequestBehavior.DenyGet);
            }
            catch(Exception e)
            {
                string reason = $"your not allowed to access the data because {e.Message}";
                return Json(reason,JsonRequestBehavior.AllowGet);
            }
        }
    }
}