namespace PlacesToEat.Services.Data
{
    using System.Linq;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models.Users;

    public class RestaurantUserService : IRestaurantUserService
    {
        private readonly IDbUserRepository<RestaurantUser> users;

        public RestaurantUserService(IDbUserRepository<RestaurantUser> users)
        {
            this.users = users;
        }

        public IQueryable<RestaurantUser> GetAll()
        {
            return this.users.All();
        }
    }
}
