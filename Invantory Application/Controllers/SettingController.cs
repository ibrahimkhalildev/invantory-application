using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Invantory_Application.Controllers
{
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult GeneralSetting()
        {
            return View();
        }
        public ActionResult MyProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyProfile(HttpPostedFileBase FileUpload)
        {
            string FileName = FileUpload.FileName;
            FileUpload.SaveAs(Server.MapPath("~/Uploads/") + FileName);

            string Url = "http://localhost:60333/Uploads/" + FileName;
            ViewBag.ImageUrl = Url;
            return View();
        }
    }
}