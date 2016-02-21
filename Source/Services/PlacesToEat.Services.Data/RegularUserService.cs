namespace PlacesToEat.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
