namespace PlacesToEat.Web.Areas.Regular.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.UserServices;
    using ViewModels.UserFavourites;
    using Web.Controllers;
    using Web.ViewModels.Restaurant;

    [Authorize(Roles = "Regular")]
    public class UserFavouritesController : BaseController
    {
        private readonly IRegularUserService users;

        public UserFavouritesController(IRegularUserService users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();

            var restaurants = this.users.GetFavourites(userId, string.Empty, (int)OrderByType.Name).To<RegularUserFavouriteViewModel>().ToList();

            var model = new UserFavouritesViewModel
            {
                OrderBy = OrderByType.Name,
                Restaurants = restaurants
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserFavouritesViewModel model)
        {
            var userId = this.User.Identity.GetUserId();

            if (model.Search == null)
            {
                model.Search = string.Empty;
            }

            var restaurants = this.users.GetFavourites(userId, model.Search, (int)model.OrderBy).To<RegularUserFavouriteViewModel>().ToList();

            model.Restaurants = restaurants;

            return this.View(model);
        }
    }
}
