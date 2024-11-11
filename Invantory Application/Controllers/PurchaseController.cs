using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invantory_Project.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult PurchaseList()
        {
            return View();
        }
        public ActionResult AddPurchase()
        {
            return View();
        }
        public ActionResult ImportPurchase()
        {
            return View();
        }
    }
}