using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sangam.Data.DbConnection;
using Sangam.Core.Model;
using Sangam.Data;
using Sangam.Web.Controllers.WebApiController;

namespace Sangam.Web.Areas.Quality.Controllers
{
    public class InChargeDashBoardController : Controller
    {
        // GET: Quality/InChargeDashBoard
        public ActionResult Index()
        {
            Response.AddHeader("Refresh", "15");
            try
            {
                dtiDbConnection db = new dtiDbConnection();
                var data = db.tbQualityDashBoard.Where(m => m.Status == "Complete");
                return View(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult QualityInChargeStatusUpdate(string id)
        {
            if (id != "")
            {
                QualityWebApiController webapi = new QualityWebApiController();
                webapi.QualityInChargeStatusUpdate(id);
            }
            return RedirectToAction("Index");
        }
    }
}