namespace PlacesToEat.Web.Areas.Regular.ViewModels.ListRegularUserEvents
{
    using System.Collections.Generic;
    using Web.ViewModels.Event;

    public class ListRegularUserEventsViewModel
    {
        public string Search { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
