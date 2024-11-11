using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invantory_Project.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult ExpenseList()
        {
            return View();
        }
        public ActionResult AddExpense()
        {
            return View();
        }
        public ActionResult ExpenseCategory()
        {
            return View();
        }
    }
}