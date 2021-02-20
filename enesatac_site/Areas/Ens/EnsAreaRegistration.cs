using System.Web.Mvc;

namespace enesatac_site.Areas.Ens
{
    public class EnsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ens";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ens_default",
                "Ens/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] {"enesatac_site.Areas.Ens.Controllers"}
            );
        }
    }
}