using Invantory_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Invantory_Application.Models.EquipmentN;

namespace Invantory_Project.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult Dashboard()
        { 
            EquipmentN baseEquipment = new EquipmentN();

            List<EquipmentN> equipment = baseEquipment.ListEquipment();
            ViewBag.equipment = equipment;

            return View();
        }
    }
}