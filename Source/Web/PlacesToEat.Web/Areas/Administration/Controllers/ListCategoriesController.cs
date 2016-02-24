namespace PlacesToEat.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.ListCategories;
    using Web.Controllers;

    [Authorize(Roles = "Administrator")]
    public class ListCategoriesController : BaseController
    {
        private ICategoryService categories;

        public ListCategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public ActionResult ListCategories()
        {
            var categoriesToDisplay = this.categories.GetFiltered(string.Empty, (int)OrderType.Id).To<CategoryAdvancedViewModel>().ToList();

            var model = new AdministerCategoriesViewModel
            {
                Search = string.Empty,
                Order = OrderType.Id,
                Categories = categoriesToDisplay
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListCategories(AdministerCategoriesViewModel model)
        {
            var search = model.Search;

            if (search == null)
            {
                search = string.Empty;
            }

            var categoriesToDisplay = this.categories.GetFiltered(search, (int)model.Order).To<CategoryAdvancedViewModel>().ToList();

            model.Categories = categoriesToDisplay;

            return this.View(model);
        }
    }
}
