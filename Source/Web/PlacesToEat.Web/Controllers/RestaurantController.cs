namespace PlacesToEat.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using Services.Data.Contracts.UserServices;
    using ViewModels.Comment;
    using ViewModels.RegularUser;
    using ViewModels.Restaurant;

    public class RestaurantController : BaseController
    {
        private const double ClosestRestaurantsDistance = 1;

        private readonly IRestaurantUserService restaurants;
        private readonly ICommentService comments;

        public RestaurantController(IRestaurantUserService restaurants, ICommentService comments)
        {
            this.restaurants = restaurants;
            this.comments = comments;
        }

        [HttpGet]
        public ActionResult ClosestRestaurants(ClosestRetaurantsRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            var restaurants = this.restaurants.GetClosest(model.Latitude, model.Longitude, RestaurantController.ClosestRestaurantsDistance).To<RestaurantMapViewModel>().ToList();

            return this.PartialView("~/Views/GoogleMaps/_GoogleMapsListRestaurantsPartial.cshtml", restaurants);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var restaurant = this.restaurants.GetById(id);

            var restaurantView = this.Mapper.Map<RestaurantDetailedViewModel>(restaurant);

            return this.View(restaurantView);
        }

        [HttpPost]
        [Authorize(Roles = "Regular")]
        public ActionResult PostComment(RestaurantDetailedViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Details", model);
            }

            var commentModel = model.CommentInputModel;
            var authorId = this.User.Identity.GetUserId();
            var restaurantId = model.Id;
            var content = commentModel.Content;

            this.comments.CreateComment(authorId, restaurantId, content);

            return this.RedirectToAction("Details", new { id = model.Id });
        }
    }
}
