namespace PlacesToEat.Web.Areas.Restaurants.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.ListEvents;
    using Web.Controllers;
    using Web.ViewModels.Event;

    [Authorize(Roles = "Restaurant")]
    public class ListEventsController : BaseController
    {
        private readonly IEventService events;

        public ListEventsController(IEventService events)
        {
            this.events = events;
        }

        [HttpGet]
        public ActionResult ListEvents()
        {
            var restaurantId = this.User.Identity.GetUserId();

            var search = string.Empty;

            var events = this.events.GetAllForRestaurant(restaurantId, search).To<EventViewModel>().ToList();

            var model = new ListEventsViewModel
            {
                Search = search,
                Events = events
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListEvents(ListEventsViewModel model)
        {
            var restaurantId = this.User.Identity.GetUserId();

            if (model.Search == null)
            {
                model.Search = string.Empty;
            }

            var events = this.events.GetAllForRestaurant(restaurantId, model.Search).To<EventViewModel>().ToList();

            model.Events = events;

            return this.View(model);
        }
    }
}
