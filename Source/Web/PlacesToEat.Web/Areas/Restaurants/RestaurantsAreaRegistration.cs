namespace PlacesToEat.Web.Areas.Restaurants
{
    using System.Web.Mvc;

    public class RestaurantsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Restaurants";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Restaurants_default",
                "Restaurants/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
