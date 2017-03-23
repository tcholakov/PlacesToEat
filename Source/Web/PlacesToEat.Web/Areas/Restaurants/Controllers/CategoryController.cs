namespace PlacesToEat.Web.Areas.Restaurants.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure;
    using Infrastructure.ListGenerators;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using PlacesToEat.Web.Controllers;
    using Services.Data.Contracts;
    using Services.Data.Contracts.UserServices;
    using ViewModels.Category;
    using Web.ViewModels.Category;

    [Authorize(Roles = "Restaurant")]
    public class CategoryController : BaseController
    {
        private ICategoryService categories;
        private IRestaurantUserService restaurants;

        public CategoryController(ICategoryService categories, IRestaurantUserService restaurants)
        {
            this.categories = categories;
            this.restaurants = restaurants;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Change()
        {
            var categories = this.Cache.Get("categories", () => this.categories.GetAll().To<CategoryViewModel>().ToList(), GlobalConstants.CategoriesCacheTimeInSeconds);

            var restaurantId = this.User.Identity.GetUserId();
            var currentCategoryId = this.restaurants.GetCurrentCategoryId(restaurantId);

            if (currentCategoryId == null)
            {
                currentCategoryId = categories.Where(x => x.Name == "All").FirstOrDefault().Id;

                this.restaurants.UpdateCategory((int)currentCategoryId, restaurantId);
            }

            var model = new ChangeCategoryViewModel()
            {
                CategoryId = (int)currentCategoryId,
                Categories = DropDownListGenerator.GetCategorySelectListItems(categories)
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change(ChangeCategoryViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var restaurantId = this.User.Identity.GetUserId();
                var categoryId = model.CategoryId;

                this.restaurants.UpdateCategory(categoryId, restaurantId);
            }

            var categories = this.Cache.Get("categories", () => this.categories.GetAll().To<CategoryViewModel>().ToList(), GlobalConstants.CategoriesCacheTimeInSeconds);

            model.Categories = DropDownListGenerator.GetCategorySelectListItems(categories);

            return this.View(model);
        }
    }
}
