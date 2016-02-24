namespace PlacesToEat.Services.Data
{
    using System;
    using System.Linq;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models;

    public class EventService : IEventService
    {
        private readonly IDbRepository<Event> events;

        public EventService(IDbRepository<Event> events)
        {
            this.events = events;
        }

        public void Create(Event eventToCreate)
        {
            this.events.Add(eventToCreate);

            this.events.Save();
        }

        public IQueryable<Event> GetAllForRestaurant(string restaurantId, string search)
        {
            return this.events
                .All()
                .Where(x => x.RestaurantId == restaurantId)
                .Where(x => x.Name.Contains(search) || x.Description.Contains(search))
                .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<Event> GetAllForUser(string userId, string search)
        {
            return this.events
                .All()
                .Where(x => x.Participants.Any(u => u.Id == userId))
                .Where(x => x.Name.Contains(search) || x.Description.Contains(search) || x.Restaurant.Name.Contains(search))
                .OrderByDescending(x => x.ExpirationDate);
        }
    }
}
