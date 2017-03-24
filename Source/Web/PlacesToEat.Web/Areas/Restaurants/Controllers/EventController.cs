namespace PlacesToEat.Web.Areas.Restaurants.Controllers
{
    using System;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using Services.Data.Contracts.UserServices;
    using Tools.Infrastructure.Contracts;
    using ViewModels.Event;
    using Web.Controllers;

    [Authorize(Roles = "Restaurant")]
    public class EventController : BaseController
    {
        private readonly IRestaurantUserService restaurants;
        private readonly IEventService events;
        private readonly IUtilities utilities;

        public EventController(IRestaurantUserService restaurants, IEventService events, IUtilities utilities)
        {
            this.restaurants = restaurants;
            this.events = events;
            this.utilities = utilities;
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

            DateTime endOfTheWeek = this.utilities.GetEndOfTheWeek(DateTime.UtcNow);

            this.events.Create(model.Name, model.Description, restaurantId, endOfTheWeek);

            this.TempData["SuccessNotification"] = $"Successfuly created weekly event {model.Name}";

            return this.RedirectToAction("ListEvents", "ListEvents");
        }
    }
}
