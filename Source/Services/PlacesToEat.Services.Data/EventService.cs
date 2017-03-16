namespace PlacesToEat.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models;

    public class EventService : IEventService
    {
        private readonly IDbRepository<Event> events;

        public EventService(IDbRepository<Event> events)
        {
            this.events = events;
        }

        public void Create(string name, string describtion, string restaurantId, DateTime expirationDate)
        {
            var dbevent = new Event
            {
                Name = name,
                Description = describtion,
                RestaurantId = restaurantId,
                ExpirationDate = expirationDate
            };

            this.events.Add(dbevent);

            this.events.Save();
        }

        public IQueryable<Event> GetAllForRestaurant(string restaurantId, string search)
        {
            var events = this.events
                .All()
                .Where(x => x.RestaurantId == restaurantId)
                .Where(x => x.Name.Contains(search) || x.Description.Contains(search))
                .OrderByDescending(x => x.CreatedOn);

            return events;
        }

        public IQueryable<Event> GetAllForUser(string userId, string search)
        {
            var events = this.events
                .All()
                .Where(x => x.Restaurant.RegularUsers.Any(u => u.Id == userId))
                .Where(x => x.ExpirationDate > DateTime.UtcNow)
                .Where(x => x.Name.Contains(search) || x.Description.Contains(search) || x.Restaurant.Name.Contains(search))
                .OrderByDescending(x => x.ExpirationDate);

            return events;
        }
    }
}
