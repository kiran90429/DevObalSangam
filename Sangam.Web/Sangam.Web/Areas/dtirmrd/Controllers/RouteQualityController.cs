using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sangam.Web.Areas.dtirmrd.Controllers
{
    public class RouteQualityController : Controller
    {
        // GET: dtirmrd/RouteQuality
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RouteQuality()
        {
            return View();
        }
        public ActionResult InsertRouteQuality(Core.Model.RouteQuality res)
        {
            if (res != null)
            {
                Web.Controllers.WebApiController.WebApiController webapi = new Web.Controllers.WebApiController.WebApiController();
                webapi.CreateWebAPIRouteQuantity(res);
            }
            return Json(true);
        }

        public ActionResult GetRouteQualityDetails()
        {

            return View();

        }
    }
}