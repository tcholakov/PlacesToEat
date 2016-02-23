namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;
    using PlacesToEat.Data.Models.Users;

    public interface IRestaurantUserService
    {
        IQueryable<RestaurantUser> GetAll();

        IQueryable<RestaurantUser> GetClosest(double currentLatitude, double currentLongitude, double distanceInKilometeres);

        IQueryable<RestaurantUser> FilterRestaurants(double currentLatitude, double currentLongitude, double distanceInKilometeres, string search, int? categoryId);

        void UpdateCategory(int categoryId, string restaurantId);

        int? GetCurrentCategoryId(string restaurantId);

        RestaurantUser GetById(string restaurantId);
    }
}
