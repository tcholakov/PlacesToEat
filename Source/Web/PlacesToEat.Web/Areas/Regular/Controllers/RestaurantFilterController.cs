namespace PlacesToEat.Web.Areas.Regular.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.ListGenerators;
    using Infrastructure.Mapping;
    using PlacesToEat.Web.Controllers;
    using Services.Data.Contracts;
    using Services.Data.Contracts.UserServices;
    using ViewModels.RestaurantFilter;
    using Web.ViewModels.Category;
    using Web.ViewModels.Restaurant;

    [Authorize(Roles = "Regular")]
    public class RestaurantFilterController : BaseController
    {
        private const int CategoriesCacheTime = 60 * 60;

        private readonly IRestaurantUserService restaurants;
        private readonly ICategoryService categories;

        public RestaurantFilterController(IRestaurantUserService restaurants, ICategoryService categories)
        {
            this.restaurants = restaurants;
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var categories = this.Cache.Get("categories", () => this.categories.GetAll().To<CategoryViewModel>().ToList(), CategoriesCacheTime);

            var model = new RestaurantFilterViewModel();

            model.Categories = DropDownListGenerator.GetCategorySelectListItems(categories);

            model.Distance = 1;

            return this.View(model);
        }

        public ActionResult FilteredRestaurants(double? latitude, double? longitude, string search, int? categoryId, double distance = 1)
        {
            var zoom = 15;

            if (distance > 2 && distance <= 5)
            {
                zoom = 14;
            }
            else if (distance >= 5 && distance <= 8)
            {
                zoom = 13;
            }
            else if (distance >= 8)
            {
                zoom = 12;
            }

            if (latitude != null && longitude != null)
            {
                var restaurants = this.restaurants.FilterRestaurants((double)latitude, (double)longitude, distance, search, categoryId).To<RestaurantMapViewModel>().ToList();

                if (restaurants == null)
                {
                    return this.Redirect("/");
                }

                var model = new RestaurantMapFilterViewModel
                {
                    Zoom = zoom,
                    Restaurants = restaurants
                };

                return this.PartialView("~/Areas/Regular/Views/GoogleMaps/_GoogleMapsFilterListRestaurantsPartial.cshtml", model);
            }

            return this.Redirect("/");
        }
    }
}
