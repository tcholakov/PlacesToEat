namespace PlacesToEat.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Data.UserServices;
    using ViewModels.Category;

    public class CategoryController : BaseController
    {
        private const int CategoriesCacheTime = 60 * 60;

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
            var categories = this.Cache.Get("categories", () => this.categories.GetAll().To<CategoryViewModel>().ToList(), CategoriesCacheTime);

            var model = new ChangeCategoryViewModel();
            var restaurantId = this.User.Identity.GetUserId();
            var currentCategoryId = this.restaurants.GetCurrentCategoryId(restaurantId);

            if (currentCategoryId == null)
            {
                currentCategoryId = categories.Where(x => x.Name == "All").FirstOrDefault().Id;

                this.restaurants.UpdateCategory((int)currentCategoryId, restaurantId);
            }

            model.CategoryId = (int)currentCategoryId;
            model.Categories = this.GetCategorySelectListItems(categories);

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

            var categories = this.Cache.Get("categories", () => this.categories.GetAll().To<CategoryViewModel>().ToList(), CategoriesCacheTime);

            model.Categories = this.GetCategorySelectListItems(categories);

            return this.View(model);
        }

        private IEnumerable<SelectListItem> GetCategorySelectListItems(IEnumerable<CategoryViewModel> categories)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var category in categories)
            {
                selectList.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }

            return selectList;
        }
    }
}
