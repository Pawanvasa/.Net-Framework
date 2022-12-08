using CRUD_Operations_Without_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operations_Without_Core.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Student student = new Student() {
                StudentId = 1, StudentName = "pawan", StudentAge = 23, StudentBirthDate = new DateTime(1999/05/24)
            };
            return View(student);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}