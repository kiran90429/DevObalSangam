using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sangam.Web.Controllers.WebApiController;
using Sangam.Core.Model;

namespace Sangam.Web.Areas.dtirmrd.Controllers
{
    public class VendorTankerController : Controller
    {
        // GET: dtirmrd/VendorTanker
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsertVendorTanker(VendorTankerModel res)
        {
            if (res != null)
            {
                WebApiController webapi = new WebApiController();
                webapi.InsertVendorTanker(res);
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetAllVendorDetails()
        {
            WebApiController api = new WebApiController();
            var details = api.GetAllVendorDetails();
            return this.Json(details, JsonRequestBehavior.AllowGet);
        }
    }
}