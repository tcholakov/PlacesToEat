namespace PlacesToEat.Web.Areas.Restaurants.ViewModels.ListEvents
{
    using System.Collections.Generic;
    using Web.ViewModels.Event;

    public class ListEventsViewModel
    {
        public string Search { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
