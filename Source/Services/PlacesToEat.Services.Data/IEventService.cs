namespace PlacesToEat.Services.Data
{
    using PlacesToEat.Data.Models;

    public interface IEventService
    {
        void Create(Event eventToCreate);
    }
}
