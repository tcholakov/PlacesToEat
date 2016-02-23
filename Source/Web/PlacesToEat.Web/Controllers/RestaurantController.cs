namespace PlacesToEat.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Data.UserServices;
    using ViewModels.Comment;
    using ViewModels.RegularUser;
    using ViewModels.Restaurant;

    public class RestaurantController : BaseController
    {
        private readonly IRestaurantUserService restaurants;
        private readonly ICommentService comments;

        public RestaurantController(IRestaurantUserService restaurants, ICommentService comments)
        {
            this.restaurants = restaurants;
            this.comments = comments;
        }

        public ActionResult ClosestRestaurants(double? latitude, double? longitude)
        {
            IEnumerable<RestaurantMapViewModel> restaurants = null;

            if (latitude != null && longitude != null)
            {
                restaurants = this.restaurants.GetClosest((double)latitude, (double)longitude, 1).To<RestaurantMapViewModel>().ToList();

                return this.PartialView("~/Views/GoogleMaps/_GoogleMapsListRestaurantsPartial.cshtml", restaurants);
            }

            return this.Redirect("/");
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var restaurant = this.restaurants.GetById(id);
            var restaurantView = new RestaurantDetailedViewModel
            {
                Id = restaurant.Id,
                Address = restaurant.Address,
                Category = restaurant.Category.Name,
                Email = restaurant.Email,
                Name = restaurant.Name,
                PhoneNumber = restaurant.PhoneNumber,
                Favourites = restaurant.RegularUsers.AsQueryable().To<RegularUserViewModel>().ToList(),
                Comments = restaurant.Comments.AsQueryable().To<CommentViewModel>().ToList()
            };

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
