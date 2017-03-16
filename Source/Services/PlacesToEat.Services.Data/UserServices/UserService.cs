namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;

    using Contracts.UserServices;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models.Users;

    public class UserService : IUserService
    {
        private readonly IDbUserRepository<User> users;

        public UserService(IDbUserRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }
    }
}
