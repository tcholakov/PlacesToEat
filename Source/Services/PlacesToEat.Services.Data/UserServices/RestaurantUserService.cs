namespace PlacesToEat.Services.Data.UserServices
{
    using System;
    using System.Linq;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models.Users;
    using PlacesToEat.Web.Infrastructure.GeoLocation;

    public class RestaurantUserService : IRestaurantUserService
    {
        private readonly IDbUserRepository<RestaurantUser> restaurants;

        public RestaurantUserService(IDbUserRepository<RestaurantUser> restaurants)
        {
            this.restaurants = restaurants;
        }

        public IQueryable<RestaurantUser> GetAll()
        {
            return this.restaurants.All();
        }

        public RestaurantUser GetById(string restaurantId)
        {
            return this.restaurants.GetById(restaurantId);
        }

        public IQueryable<RestaurantUser> GetClosest(double currentLatitude, double currentLongitude, double distanceInKilometeres)
        {
            return this.restaurants
                .All()
                .ToList()
                .Where(x => GeoLocator.DistanceTo(currentLatitude, currentLongitude, x.Latitude, x.Longitude, 'K') <= distanceInKilometeres)
                .AsQueryable<RestaurantUser>();
        }

        public int? GetCurrentCategoryId(string restaurantId)
        {
            var restaurant = this.restaurants.GetById(restaurantId);
            var categoryId = restaurant.CategoryId;

            return categoryId;
        }

        public void UpdateCategory(int categoryId, string restaurantId)
        {
            var restaurant = this.restaurants.GetById(restaurantId);

            restaurant.CategoryId = categoryId;

            this.restaurants.Save();
        }
    }
}
