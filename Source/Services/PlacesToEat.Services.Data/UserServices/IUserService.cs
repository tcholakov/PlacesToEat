namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;
    using PlacesToEat.Data.Models.Users;

    public interface IUserService
    {
        IQueryable<User> GetAll();
    }
}
