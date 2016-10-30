using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sangam.Web.Controllers.WebApiController;

namespace Sangam.Web.Areas.dtirmrd.Controllers
{
    public class TankerQualityController : Controller
    {
        // GET: dtirmrd/TankerQuality
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetTankerQualityDetails(string rSTNo,string rCellType)
        {
            WebApiController api = new WebApiController();
            var details = api.GetTankerQualityDetails(rSTNo, rCellType);
            return this.Json(details, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTankerDetails(string rSTNo)
        {
            WebApiController api = new WebApiController();
            var details = api.GetTankerDetails(rSTNo);
            return this.Json(details, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetWeighmentInDetails(string id)
        {
            Web.Controllers.WebApiController.WebApiController webapi = new Web.Controllers.WebApiController.WebApiController();
            List<Core.Model.WeighmentModel> obj = new List<Core.Model.WeighmentModel>();
            try
            {
                Core.Model.WeighmentModel result = new Core.Model.WeighmentModel();
                Data.DbConnection.dtiDbConnection db = new Data.DbConnection.dtiDbConnection();

                result = db.tblWeighment.Where(m => m.RefNo == id).FirstOrDefault();
                Session["Id"] = result.RefNo.ToString();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult TankerQualitySaveUpdate(Core.Model.TankerQualityModel res)
        {
            ModelState.AddModelError(string.Empty, "Please write first name.");
            if (res != null)
            {
                Web.Controllers.WebApiController.WebApiController webapi = new Web.Controllers.WebApiController.WebApiController();
                webapi.CreateWebAPITankerDataSaveUpdate(res);
            }
            return RedirectToAction("Index");
        }

    }
}