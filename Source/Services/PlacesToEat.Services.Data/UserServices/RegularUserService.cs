namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models.Users;

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

        public IQueryable<RestaurantUser> GetFavourites(string id, string search, int order)
        {
            var user = this.users.GetById(id);

            var result = user.FavouriteRestaurants
                    .Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Address.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower()));

            switch (order)
            {
                case 1: result = result.OrderBy(x => x.Name);
                    break;
                case 2: result = result.OrderBy(x => x.Address);
                    break;
                case 3: result = result.OrderBy(x => x.Category.Name);
                    break;
                case 4: result = result.OrderBy(x => x.Email);
                    break;
                case 5: result = result.OrderByDescending(x => x.RegularUsers.Count);
                    break;
            }

            return result.AsQueryable<RestaurantUser>();
        }
    }
}
