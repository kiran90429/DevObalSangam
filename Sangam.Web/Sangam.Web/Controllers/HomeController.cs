using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sangam.Data.DbConnection;
using System.Data.Entity;
using Sangam.SharedLibraries;

namespace Sangam.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<dtiDbConnection>());
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UserLoginControl(Core.Model.MemberLogin res)
        {
            if (res != null)
            {
                SharedLibraries.stCommon.CommonActionsLibrary ap = new SharedLibraries.stCommon.CommonActionsLibrary();
                string uname = ap.UserLogin(res);
                if (uname != "false")
                {
                    return RedirectToAction("../dtirmrd/DashBoard/DashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Please write first name.");
                    return RedirectToAction("Index");
                }
            }
            return Json(true);
        }
    }
}