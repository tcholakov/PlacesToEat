namespace PlacesToEat.Services.Data
{
    using System;
    using System.Linq;
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
