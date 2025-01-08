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

            List<EquipmentN> DDLEquipment = baseEquipment.LoadEquipmentDDL();
            ViewBag.DDLEquipment = DDLEquipment;

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
           // equipmentN.ReceivedDate = Convert.ToDateTime(frmCollection["txtEquipmentReceivedvDate"]);
            equipmentN.ReceivedDate = DateTime.ParseExact(frmCollection["txtEquipmentReceivedvDate"].ToString(), "MM/dd/yyyy", null);
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
            int custid = Convert.ToInt32(frmCollection["txtCustomerID"].ToString());
            int equipId = Convert.ToInt32(frmCollection["txtEquipmentID"].ToString());
            int equipCount = Convert.ToInt32(frmCollection["txtEquipmentCount"].ToString());

            int returnResult = Employee.SaveAssignment(custid,equipId,equipCount);
            Session["OpMsg"] = "Operation Failed";
            if (returnResult == 1)
            {
                Session["OpMsg"] = "Saved Successfull!";
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public JsonResult GetName(int memberType) //int memberType  //Controller Name/Json Function Name ||
        {
            //var Human = new
            //{
            //    Name = "Ibrahim Khalil",
            //    Age = 31,
            //    Address = "Dhaka"
            //};

            //return Json(Human, JsonRequestBehavior.AllowGet);
            List<Member> My_Members = new List<Member>();
            Member member = new Member();
            member.Name = "Member 1";
            My_Members.Add(member);

            member = new Member();
            member.Name = "Member 2";
            My_Members.Add(member);

            member = new Member();
            member.Name = "Member 2";
            My_Members.Add(member);

            return Json(My_Members, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveName(Member member)
        {
            return Json(member.Name, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DoSum(int b, int v)
        {
            return Json((b + v), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DoSubstract(int x, int y) 
        {
            return Json((x-y),JsonRequestBehavior.AllowGet);
        }

        public ActionResult EquipmentByCustomerData() 
        {
            CustomerList customerList = new CustomerList();
            customerList.Query_for_Equipment_List(1);
            return View(); 
        }

        public JsonResult GetEquipment(int CustomerId) // http://localhost:60333/Inventory/GetEquipment?CustomerId=1

        {
            CustomerList customerList = new CustomerList();
            var customerdata=  customerList.Query_for_Equipment_List(CustomerId);
            return Json(customerdata, JsonRequestBehavior.AllowGet);
        }

    }
}