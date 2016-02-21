namespace PlacesToEat.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;
    using Infrastructure.GeoLocation;

    public class HomeController : BaseController
    {
        private readonly IUserService users;
        private readonly IRegularUserService regularUsers;
        private readonly IRestaurantUserService restaurantUsers;

        public HomeController(IUserService users, IRegularUserService regularUsers, IRestaurantUserService restaurantUsers)
        {
            this.users = users;
            this.regularUsers = regularUsers;
            this.restaurantUsers = restaurantUsers;
        }

        public ActionResult Index()
        {
            var users = this.users.GetAll().ToList();
            var regularUsers = this.regularUsers.GetAll().ToList();

            var restaurant = this.restaurantUsers.GetAll().FirstOrDefault();

            double myLatitude = 42.6754744;
            double myLongitude = 23.287862099999984;

            var distance = GeoLocator.DistanceTo(myLatitude, myLongitude, restaurant.Latitude, restaurant.Longitude);

            return this.View(distance);
        }
    }
}
