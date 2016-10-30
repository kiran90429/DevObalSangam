using System.Web.Mvc;

namespace Sangam.Web.Areas.dtirmrd
{
    public class dtirmrdAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "dtirmrd";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "dtirmrd_default",
                "dtirmrd/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}