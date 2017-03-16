namespace PlacesToEat.Web.Areas.Regular.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using PlacesToEat.Web.Controllers;
    using Services.Data.Contracts;
    using ViewModels.ListRegularUserEvents;
    using Web.ViewModels.Event;

    [Authorize(Roles = "Regular")]
    public class ListRegularUserEventsController : BaseController
    {
        private readonly IEventService events;

        public ListRegularUserEventsController(IEventService events)
        {
            this.events = events;
        }

        [HttpGet]
        public ActionResult ListEvents()
        {
            var userId = this.User.Identity.GetUserId();
            var search = string.Empty;

            var events = this.events.GetAllForUser(userId, search).To<EventViewModel>().ToList();

            var model = new ListRegularUserEventsViewModel
            {
                Search = search,
                Events = events
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListEvents(ListRegularUserEventsViewModel model)
        {
            var userId = this.User.Identity.GetUserId();

            if (model.Search == null)
            {
                model.Search = string.Empty;
            }

            var events = this.events.GetAllForUser(userId, model.Search).To<EventViewModel>().ToList();

            model.Events = events;

            return this.View(model);
        }
    }
}
