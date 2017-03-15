namespace PlacesToEat.Services.Data
{
    using System.Linq;

    using PlacesToEat.Data.Models;

    public interface IEventService
    {
        void Create(Event eventToCreate);

        IQueryable<Event> GetAllForRestaurant(string restaurantId, string search);

        IQueryable<Event> GetAllForUser(string userId, string search);
    }
}
