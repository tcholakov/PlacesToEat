namespace PlacesToEat.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.UserServices;
    using ViewModels.Restaurant;

    public class RestaurantController : BaseController
    {
        private readonly IRestaurantUserService restaurantUsers;

        public RestaurantController(IRestaurantUserService restaurantUsers)
        {
            this.restaurantUsers = restaurantUsers;
        }

        public ActionResult ClosestRestaurants(double? latitude, double? longitude)
        {
            IEnumerable<RestaurantMapViewModel> restaurants = null;

            if (latitude != null && longitude != null)
            {
                restaurants = this.restaurantUsers.GetClosest((double)latitude, (double)longitude, 1).To<RestaurantMapViewModel>().ToList();

                return this.PartialView("~/Views/GoogleMaps/_GoogleMapsListRestaurantsPartial.cshtml", restaurants);
            }

            return this.Redirect("/");
        }
    }
}
