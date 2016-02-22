namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models.Users;

    public class RegularUserService : IRegularUserService
    {
        private readonly IDbUserRepository<RegularUser> users;

        public RegularUserService(IDbUserRepository<RegularUser> users)
        {
            this.users = users;
        }

        public IQueryable<RegularUser> GetAll()
        {
            return this.users.All();
        }
    }
}
