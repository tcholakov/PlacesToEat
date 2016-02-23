namespace PlacesToEat.Web.Areas.Regular
{
    using System.Web.Mvc;

    public class RegularAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Regular";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Regular_default",
                "Regular/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
