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
    }
}
