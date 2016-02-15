namespace PlacesToEat.Services.Data
{
    using System;
    using System.Linq;
    using PlacesToEat.Data.Models.Users;

    public class UserService : IUsersService
    {
        //private readonly IDbRepository<ApplicationUser, string> users;

        //public UserService(IDbRepository<ApplicationUser, string> users)
        //{
        //    this.users = users;
        //}

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
