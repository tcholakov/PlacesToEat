namespace PlacesToEat.Web.Areas.Restaurants.Controllers
{
    using System;
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Data.UserServices;
    using ViewModels.Event;
    using Web.Controllers;

    [Authorize(Roles = "Restaurant")]
    public class EventController : BaseController
    {
        private readonly IRestaurantUserService restaurants;
        private readonly IEventService events;

        public EventController(IRestaurantUserService restaurants, IEventService events)
        {
            this.restaurants = restaurants;
            this.events = events;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.View(model);
            }

            var restaurantId = this.User.Identity.GetUserId();

            DateTime baseDate = DateTime.UtcNow;
            DateTime thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            DateTime thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

            var restaurant = this.restaurants.GetById(restaurantId);

            var dbevent = new Event
            {
                Name = model.Name,
                Description = model.Description,
                RestaurantId = restaurantId,
                ExpirationDate = thisWeekEnd
            };

            this.events.Create(dbevent);

            return this.RedirectToAction("ListEvents", "ListEvents");
        }
    }
}
