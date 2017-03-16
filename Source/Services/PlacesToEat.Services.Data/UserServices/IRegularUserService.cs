namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;

    using PlacesToEat.Data.Models.Users;
    using PlacesToEat.Web.Infrastructure.CommonTypes;

    public interface IRegularUserService
    {
        IQueryable<RegularUser> GetAll();

        void Favourite(string userId, string restaurantId);

        void Unfavourite(string userId, string restaurantId);

        IQueryable<RestaurantUser> GetFavouriteRestaurants(string id, string search, RestaurantsOrderBy order);
    }
}
