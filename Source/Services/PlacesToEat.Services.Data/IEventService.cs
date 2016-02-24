namespace PlacesToEat.Services.Data
{
    using PlacesToEat.Data.Models;
    using System.Linq;

    public interface IEventService
    {
        void Create(Event eventToCreate);

        IQueryable<Event> GetAllForRestaurant(string restaurantId, string search);

        IQueryable<Event> GetAllForUser(string userId, string search);
    }
}
