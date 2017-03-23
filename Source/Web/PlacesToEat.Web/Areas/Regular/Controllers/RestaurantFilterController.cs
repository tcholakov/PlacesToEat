namespace PlacesToEat.Web.Areas.Regular.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.ListGenerators;
    using Infrastructure.Mapping;
    using PlacesToEat.Web.Controllers;
    using Services.Data.Contracts;
    using Services.Data.Contracts.UserServices;
    using Services.Geo.Contracts;
    using ViewModels.RestaurantFilter;
    using Web.ViewModels.Category;
    using Web.ViewModels.Restaurant;
    using Infrastructure;

    [Authorize(Roles = "Regular")]
    public class RestaurantFilterController : BaseController
    {
        private readonly IRestaurantUserService restaurants;
        private readonly ICategoryService categories;
        private readonly IGoogleMapsService googleMapsService;

        public RestaurantFilterController(IRestaurantUserService restaurants, ICategoryService categories, IGoogleMapsService googleMapsService)
        {
            this.restaurants = restaurants;
            this.categories = categories;
            this.googleMapsService = googleMapsService;
        }

        public ActionResult Index()
        {
            var categories = this.Cache.Get("categories", () => this.categories.GetAll().To<CategoryViewModel>().ToList(), GlobalConstants.CategoriesCacheTimeInSeconds);

            var model = new RestaurantFilterResponseViewModel
            {
                Distance = 1,
                Categories = DropDownListGenerator.GetCategorySelectListItems(categories)
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult FilteredRestaurants(RestaurantFilterRequestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            if (model.Search == null)
            {
                model.Search = string.Empty;
            }

            if (model.Distance == null || model.Distance <= 0)
            {
                model.Distance = 1;
            }

            var restaurants = this.restaurants.FilterRestaurants(model.Latitude, model.Longitude, (double)model.Distance, model.Search, model.CategoryId)
                .To<RestaurantMapViewModel>()
                .ToList();

            if (restaurants == null)
            {
                return this.Redirect("/");
            }

            int zoom = this.googleMapsService.GetBestGoogleMapsZoom((double)model.Distance);

            var mapModel = new RestaurantMapFilterViewModel
            {
                Zoom = zoom,
                Restaurants = restaurants
            };

            return this.PartialView("~/Areas/Regular/Views/GoogleMaps/_GoogleMapsFilterListRestaurantsPartial.cshtml", mapModel);
        }
    }
}
