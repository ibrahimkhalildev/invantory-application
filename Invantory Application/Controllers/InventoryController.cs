﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invantory_Project.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}