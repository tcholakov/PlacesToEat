namespace PlacesToEat.Services.Data
{
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
    }
}
