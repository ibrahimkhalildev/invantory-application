using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invantory_Project.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Saleslist()
        {
            return View();
        }
        public ActionResult Pos()
        {
            return View();
        }
    }
}