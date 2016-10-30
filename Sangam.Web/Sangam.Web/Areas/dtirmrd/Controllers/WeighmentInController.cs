using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sangam.Data;
using Sangam.Data.DbConnection;
using System.Net;
using Sangam.Core;

namespace Sangam.Web.Areas.dtirmrd.Controllers
{
    public class WeighmentInController : Controller
    {
        // GET: dtirmrd/WeighmentIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WeighmentIn()
        {
            try
            {
                dtiDbConnection db = new dtiDbConnection();
                var data = db.tblWeighment.Where(m => m.QCStatus == "O");
                return View(data.ToList());

            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult GetWeighmentInforEdit(int? id)
        {
            Web.Controllers.WebApiController.WebApiController webapi = new Web.Controllers.WebApiController.WebApiController();
            List<Core.Model.WeighmentModel> obj = new List<Core.Model.WeighmentModel>();

            obj = webapi.GetWeighmentInforEdit(id);

            Core.Model.WeighmentModel result = new Core.Model.WeighmentModel();
            result.GrossWeight = obj[0].GrossWeight;
            result.ProductType = obj[0].ProductType;
            result.RefNo = obj[0].RefNo;
            result.Slno = obj[0].Slno;
            result.VendorName = obj[0].VendorName;
            result.VehicleNo = obj[0].VehicleNo;
            result.WeighingBy = obj[0].WeighingBy;
            result.WeighmentId = obj[0].WeighmentId;
            result.DateTime = obj[0].DateTime;
            return PartialView("WeighmentInEdit", result);
        }

        public ActionResult InsertWeighmentIn(Core.Model.WeighmentModel res)
        {
            ModelState.AddModelError(string.Empty, "Please write first name.");
            if (res != null)
            {
                Web.Controllers.WebApiController.WebApiController webapi = new Web.Controllers.WebApiController.WebApiController();
                webapi.CreateWebAPIWeighmentIn(res);
            }
            return RedirectToAction("WeighmentIn");
        }
        public ActionResult WeighmentInAddNew()
        {
            try
            {
                dtiDbConnection db = new dtiDbConnection();
                //var data = db.tblWeighment.LastOrDefault(m => m.QCStatus == m.QCStatus);
                int k = db.tblWeighment.Count();

                if (k > 0)
                {
                    int val = db.tblWeighment.Max(m => m.WeighmentId);
                    Session["NextId"] = val + 1;
                }
                else
                {
                    Session["NextId"] = 1;
                }
                return View();

            }
            catch (Exception)
            {
                throw;
            }
            //return View();
        }
        public ActionResult DeleteItems(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dtiDbConnection db = new dtiDbConnection();
            Core.Model.WeighmentModel personalDetail = db.tblWeighment.Find(id);
            if (personalDetail == null)
            {
                return HttpNotFound();
            }

            Web.Controllers.WebApiController.WebApiController api = new Web.Controllers.WebApiController.WebApiController();
            api.DeleteItems(id.Value);
            return this.RedirectToAction("WeighmentIn");

            //return null;
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dtiDbConnection db = new dtiDbConnection();
            Core.Model.WeighmentModel personalDetail = db.tblWeighment.Find(id);
            db.tblWeighment.Remove(personalDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private static IEnumerable<Core.Model.WeighmentModel> GetBeamlines()
        {
            var context = new Data.DbConnection.dtiDbConnection();
            return context.tblWeighment.Select(b => new Core.Model.WeighmentModel
            {
                WeighmentId = b.WeighmentId,
                RefNo = b.RefNo,
                VehicleNo = b.VehicleNo
            });
        }
    }
}