using Invantory_Application.Models;
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
            Member objMember = new Member();
            objMember.ValidateMember(UserName, Password);
            if (objMember.Name != "") //(UserName == "ibrahim" && Password == "123")
            {
                Session["UserName"] = UserName; //+ "("+objMember.Role + ")";
                Session["AutmemberInfo"] = objMember;
                ViewBag.Msg = "You are Logged in Successfully!";
            }
            else
            {
                ViewBag.Msg = "Incorrect Username or Password!";
            }
            return View();
        } 
        public ActionResult Logout() 
        {
            Session.Remove("UserName");
            return RedirectToAction("Login");
        }
    }
}