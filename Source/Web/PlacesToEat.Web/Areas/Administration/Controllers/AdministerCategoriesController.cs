namespace PlacesToEat.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using PlacesToEat.Web.Controllers;
    using Services.Data;
    using ViewModels.AdministerCategories;

    [Authorize(Roles = "Administrator")]
    public class AdministerCategoriesController : BaseController
    {
        private ICategoryService categories;

        public AdministerCategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.categories.Create(model.Name);

            return this.RedirectToAction("ListCategories", "ListCategories");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.categories.Delete(id);

            return this.RedirectToAction("ListCategories", "ListCategories");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var category = this.categories.GetById(id).To<CategoryUpdateInputModel>().FirstOrDefault();

            return this.View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CategoryUpdateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.categories.Update(model.Id, model.Name);

            return this.RedirectToAction("ListCategories", "ListCategories");
        }
    }
}
