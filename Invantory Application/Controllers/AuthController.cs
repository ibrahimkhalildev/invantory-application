using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invantory_Application.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            if (UserName == "admin" && Password == "123")
            {

                ViewBag.Msg = "You are Lgged in Successfully!";
            }
            else
            {
                ViewBag.Msg = "Login Failed, Try Again!";
            }
            return View();
        }
        public ActionResult Login2()
        {
            return View();
        }
    }
}