using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sangam.Core.Model;
using Sangam.Data.DbConnection;
using Sangam.Web.Controllers.WebApiController;

namespace Sangam.Web.Areas.Quality.Controllers
{
    public class QualityDashBoardController : Controller
    {
        // GET: Quality/QualityDashBoard
        public ActionResult Index()
        {
            Response.AddHeader("Refresh", "15");
            try
            {
                dtiDbConnection db = new dtiDbConnection();
                var data = db.tbQualityDashBoard.Where(m => m.Status == "Pending");
                return View(data.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult QualityStatusUpdate(string id)
        {
            if (id != "")
            {
                QualityWebApiController webapi = new QualityWebApiController();
                webapi.QualityStatusUpdate(id);
            }
            return RedirectToAction("Index");
        }
    }
}