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

        public IQueryable<RestaurantUser> GetClosest(double currentLatitude, double currentLongitude, double distanceInKilometeres)
        {
            return this.restaurants
                .All()
                .ToList()
                .Where(x => GeoLocator.DistanceTo(currentLatitude, currentLongitude, x.Latitude, x.Longitude, 'K') <= distanceInKilometeres)
                .AsQueryable<RestaurantUser>();
        }
    }
}
