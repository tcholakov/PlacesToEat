namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;

    using Contracts.UserServices;
    using PlacesToEat.Data.Common.Contracts;
    using PlacesToEat.Data.Models.Users;
    using Tools.Infrastructure.CommonTypes;

    public class RegularUserService : IRegularUserService
    {
        private readonly IDbUserRepository<RegularUser> users;
        private readonly IDbUserRepository<RestaurantUser> restaurants;

        public RegularUserService(IDbUserRepository<RegularUser> users, IDbUserRepository<RestaurantUser> restaurants)
        {
            this.users = users;
            this.restaurants = restaurants;
        }

        public void Favourite(string userId, string restaurantId)
        {
            var user = this.users.GetById(userId);
            var restaurant = this.restaurants.GetById(restaurantId);

            user.FavouriteRestaurants.Add(restaurant);

            this.users.Save();
        }

        public void Unfavourite(string userId, string restaurantId)
        {
            var user = this.users.GetById(userId);
            var restaurant = this.restaurants.GetById(restaurantId);

            user.FavouriteRestaurants.Remove(restaurant);

            this.users.Save();
        }

        public IQueryable<RegularUser> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<RestaurantUser> GetFavouriteRestaurants(string id, string search, RestaurantsOrderBy order)
        {
            var user = this.users.GetById(id);

            var result = user.FavouriteRestaurants
                    .Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Address.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower()));

            switch (order)
            {
                case RestaurantsOrderBy.Name: result = result.OrderBy(x => x.Name);
                    break;
                case RestaurantsOrderBy.Address: result = result.OrderBy(x => x.Address);
                    break;
                case RestaurantsOrderBy.Category: result = result.OrderBy(x => x.Category.Name);
                    break;
                case RestaurantsOrderBy.Email: result = result.OrderBy(x => x.Email);
                    break;
                case RestaurantsOrderBy.Favourites: result = result.OrderByDescending(x => x.RegularUsers.Count);
                    break;
            }

            return result.AsQueryable<RestaurantUser>();
        }
    }
}
