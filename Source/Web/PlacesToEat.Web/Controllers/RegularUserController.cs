namespace PlacesToEat.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Data.UserServices;

    public class RegularUserController : BaseController
    {
        private readonly IRegularUserService users;

        public RegularUserController(IRegularUserService users)
        {
            this.users = users;
        }

        public ActionResult Favourite(string id)
        {
            var restaurantId = id;
            var userId = this.User.Identity.GetUserId();

            this.users.Favourite(userId, restaurantId);

            return this.RedirectToAction("Details", "Restaurant", new { id = restaurantId });
        }

        public ActionResult Unfavourite(string id)
        {
            var restaurantId = id;
            var userId = this.User.Identity.GetUserId();

            this.users.Unfavourite(userId, restaurantId);

            return this.RedirectToAction("Details", "Restaurant", new { id = restaurantId });
        }
    }
}
