namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;

    using Contracts.UserServices;
    using Geo.Contracts;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models;
    using PlacesToEat.Data.Models.Users;

    public class RestaurantUserService : IRestaurantUserService
    {
        private readonly IDbUserRepository<RestaurantUser> restaurants;
        private readonly IDbRepository<Category> categories;

        private readonly IGeoLocatorService geoLocator;

        public RestaurantUserService(IDbUserRepository<RestaurantUser> restaurants, IDbRepository<Category> categories, IGeoLocatorService geoLocator)
        {
            this.restaurants = restaurants;
            this.categories = categories;
            this.geoLocator = geoLocator;
        }

        public IQueryable<RestaurantUser> FilterRestaurants(double currentLatitude, double currentLongitude, double distanceInKilometeres, string search, int? categoryId)
        {
            IQueryable<RestaurantUser> result = this.restaurants
                .All()
                .Where(x => x.Name.Contains(search) || x.Address.Contains(search.ToLower()) || x.Email.Contains(search));

            if (categoryId == null || categoryId == this.categories.All().Where(x => x.Name == "All").Select(x => x.Id).FirstOrDefault())
            {
                result = result
                            .ToList()
                            .Where(x => this.geoLocator.DistanceTo(currentLatitude, currentLongitude, x.Latitude, x.Longitude, 'K') <= distanceInKilometeres)
                            .AsQueryable<RestaurantUser>();
            }
            else
            {
                result = result
                            .Where(x => x.CategoryId == categoryId)
                            .ToList()
                            .Where(x => this.geoLocator.DistanceTo(currentLatitude, currentLongitude, x.Latitude, x.Longitude, 'K') <= distanceInKilometeres)
                            .AsQueryable<RestaurantUser>();
            }

            return result;
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
                            .Where(x => this.geoLocator.DistanceTo(currentLatitude, currentLongitude, x.Latitude, x.Longitude, 'K') <= distanceInKilometeres)
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
