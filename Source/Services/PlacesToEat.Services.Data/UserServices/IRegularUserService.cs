namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;
    using PlacesToEat.Data.Models.Users;

    public interface IRegularUserService
    {
        IQueryable<RegularUser> GetAll();

        void Favourite(string userId, string restaurantId);

        void Unfavourite(string userId, string restaurantId);

        IQueryable<RestaurantUser> GetFavourites(string id, string search, int order);
    }
}
