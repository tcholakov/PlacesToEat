namespace PlacesToEat.Services.Data
{
    using System;
    using System.Linq;

    using PlacesToEat.Data.Models;

    public interface IEventService
    {
        void Create(string name, string describtion, string restaurantId, DateTime expirationDate);

        IQueryable<Event> GetAllForRestaurant(string restaurantId, string search);

        IQueryable<Event> GetAllForUser(string userId, string search);
    }
}
