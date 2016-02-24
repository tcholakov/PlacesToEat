namespace PlacesToEat.Services.Data.UserServices
{
    using System;
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

            IQueryable<RestaurantUser> result = null;

            if (order == 1)
            {
                result = user.FavouriteRestaurants
                    .Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Address.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower()))
                    .OrderBy(x => x.Name)
                    .AsQueryable<RestaurantUser>();
            }
            else if (order == 2)
            {
                result = user.FavouriteRestaurants
                    .Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Address.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower()))
                    .OrderBy(x => x.Address)
                    .AsQueryable<RestaurantUser>();
            }
            else if (order == 3)
            {
                result = user.FavouriteRestaurants
                    .Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Address.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower()))
                    .OrderBy(x => x.Category.Name)
                    .AsQueryable<RestaurantUser>();
            }
            else if (order == 4)
            {
                result = user.FavouriteRestaurants
                    .Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Address.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower()))
                    .OrderBy(x => x.Email)
                    .AsQueryable<RestaurantUser>();
            }
            else if (order == 5)
            {
                result = user.FavouriteRestaurants
                    .Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Address.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower()))
                    .OrderByDescending(x => x.RegularUsers.Count)
                    .AsQueryable<RestaurantUser>();
            }

            return result;
        }
    }
}
