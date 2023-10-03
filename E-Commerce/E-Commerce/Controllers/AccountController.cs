using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using E_Commerce.Services;
using System.Web.UI;
using E_Commerce.Models.EntityClasses;
using AutoMapper;
namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        UserDBAccessService dbAccess;

        public AccountController()
        {
            dbAccess = new UserDBAccessService();
        }

        public ActionResult Login()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            if (userId == 0)
            {
                return View();
            }

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDetails user)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var userExist = await dbAccess.ValidateUser(user);
                    if (userExist.Count() > 0)
                    {
                        Session["UserId"] = userExist.FirstOrDefault().UserId;
                        FormsAuthentication.SetAuthCookie(user.UserName, false);
                        if (user.UserName == "Admin" && user.Password == "Admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "UserName or password is wrong");
                    return View(user);
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage","Home");
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserEntity users)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    dbAccess.Create(users);
                    return RedirectToAction("Login");
                }
                else
                {
                    return this.View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        public ActionResult SignOut(UserTable user)
        {
            try
            {
                Session.Clear();
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> ForgotPassword(string userName) 
        {
            try
            {
                if (userName != null)
                {
                    var users = await dbAccess.Get();
                    var user = users.Where(x => x.UserName == userName);
                    if (user.Count() > 0)
                    {
                        int id = user.FirstOrDefault().UserId;
                        return RedirectToAction("ChangePassword", new { userid = id });
                    }
                    ModelState.AddModelError("", "Invalid User Name");
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public  ActionResult ChangePassword(int userid)
        {
            try
            {
                ViewBag.userid = userid;
                return View();
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> updatePassword(int userid,string newpwd,string cfnpwd)
        {
            try
            {
                if (userid != 0 && newpwd != null && cfnpwd != null)
                {
                    var user = new UserTable();
                    user.Password = newpwd;
                    var isPasswordChaneged = await dbAccess.UpdatePassword(userid, user);
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Invalid Entry");
                return this.View();
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

    }
}