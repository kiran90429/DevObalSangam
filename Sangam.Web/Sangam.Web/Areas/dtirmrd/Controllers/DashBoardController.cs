using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sangam.Core.Model;
using Sangam.Data.DbConnection;

namespace Sangam.Web.Areas.dtirmrd.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: dtirmrd/DashBoard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DashBoard()
        {
            Response.AddHeader("Refresh", "15");

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
    }
}