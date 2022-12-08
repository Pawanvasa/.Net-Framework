using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LoginApp.Models;

namespace LoginApp.Controllers
{
    public class AccountController : Controller
    {
        CRUDEntities1 entity; 
        public AccountController()
        {
            entity =new CRUDEntities1();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userExist = entity.UserTables.Any(x => x.UserName == user.UserName && x.Password == user.Password);
            UserTable u = entity.UserTables.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "UserName or password is wrong");
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserTable user)
        {
            entity.UserTables.Add(user);
            entity.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult SignOut(UserTable user)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

       /* void ConnectionString()
        {
            connection.ConnectionString = "Data Source=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=CRUD;Integrated Security=SSPI";
        }*/

        /*public ActionResult Verify(Account account)
        {
            ConnectionString();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from login where username='" + account.UserName + "'and password='" + account.Password + "'";
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                return View("LoginSuccess");
            }
            else
            {
                connection.Close();
                return View("Verify");
            }
        }*/
    }
}