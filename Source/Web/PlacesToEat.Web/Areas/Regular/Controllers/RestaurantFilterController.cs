namespace PlacesToEat.Web.Areas.Regular.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using PlacesToEat.Web.Controllers;
    using Services.Data.UserServices;
    using ViewModels;
    using Web.ViewModels.Restaurant;

    [Authorize(Roles = "Regular")]
    public class RestaurantFilterController : BaseController
    {
        private readonly IRestaurantUserService restaurants;

        public RestaurantFilterController(IRestaurantUserService restaurants)
        {
            this.restaurants = restaurants;
        }

        public ActionResult Index()
        {
            var model = new RestaurantFilterViewModel();

            return this.View(model);
        }

        public ActionResult FilteredRestaurants(double? latitude, double? longitude, string search, int? categoryId, double? distance)
        {
            IEnumerable<RestaurantMapViewModel> restaurants = null;

            if (latitude != null && longitude != null)
            {
                restaurants = this.restaurants.GetClosest((double)latitude, (double)longitude, 1).To<RestaurantMapViewModel>().ToList();

                return this.PartialView("~/Views/GoogleMaps/_GoogleMapsListRestaurantsPartial.cshtml", restaurants);
            }

            return this.RedirectToAction("Index");
        }
    }
}
