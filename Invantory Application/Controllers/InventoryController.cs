﻿using Invantory_Application.Models;
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
        public ActionResult SaveEquipment(FormCollection frmCollection)
        {
            //EquipmentN baseEquipment = new EquipmentN();

            //List<EquipmentN> equipment = baseEquipment.ListEquipment();
            //ViewBag.equipment = equipment;

            EquipmentN equipmentN = new EquipmentN();

            equipmentN.EquipmentName = frmCollection["txtEquipmentName"].ToString();
            equipmentN.Quantity = Convert.ToInt32(frmCollection["txtEquipmentQuantity"].ToString());
            equipmentN.ReceivedDate = DateTime.ParseExact(frmCollection["txtEquipmentReceivedvDate"].ToString(), "dd/MM/yyyy", null);
            int returnResult = equipmentN.SaveEquipment();

            Session["OpMsg"] = "Operation Failed";
            if (returnResult == 1)
            {
                Session["OpMsg"] = "Saved Successfull!";
            }

            return RedirectToAction("Dashboard");
        }
        public ActionResult SaveAssignment(FormCollection frmCollection)
        {

            EquipmentN equipmentN = new EquipmentN();

            equipmentN.EquipmentName = frmCollection["txtEquipmentName"].ToString();
            equipmentN.Quantity = Convert.ToInt32(frmCollection["txtEquipmentQuantity"].ToString());
            equipmentN.ReceivedDate = DateTime.ParseExact(frmCollection["txtEquipmentReceivedvDate"].ToString(), "dd/MM/yyyy", null);
            int returnResult = equipmentN.SaveEquipment();

            Session["OpMsg"] = "Operation Failed";
            if (returnResult == 1)
            {
                Session["OpMsg"] = "Saved Successfull!";
            }

            return RedirectToAction("Dashboard");
        }

    }
}