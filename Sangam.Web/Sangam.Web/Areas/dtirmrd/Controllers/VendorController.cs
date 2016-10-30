using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sangam.Web.Areas.dtirmrd.Controllers
{
    public class VendorController : Controller
    {
        // GET: dtirmrd/Vendor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsertVendor(Core.Model.VendorModel res)
        {             
            if (res != null)
            {
                Web.Controllers.WebApiController.WebApiController webapi = new Web.Controllers.WebApiController.WebApiController();
                webapi.InsertVendor(res);
            }
            return RedirectToAction("Index");
        }
    }
}