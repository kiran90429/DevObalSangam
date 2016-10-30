using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sangam.Core.Model;
using Sangam.Web.Controllers.WebApiController;

namespace Sangam.Web.Areas.dtirmrd.Controllers
{
    public class TankerUnloadController : Controller
    {
        // GET: dtirmrd/TankerUnload
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDashBoardQualityDetails(string rSTNo)
        {
            QualityWebApiController webapi = new QualityWebApiController();
            var details = webapi.GetDashBoardQualityDetails(rSTNo);

            return this.Json(details, JsonRequestBehavior.AllowGet);
        }

    }
}