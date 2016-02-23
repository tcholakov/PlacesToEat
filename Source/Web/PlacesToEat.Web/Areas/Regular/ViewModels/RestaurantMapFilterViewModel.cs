namespace PlacesToEat.Web.Areas.Regular.ViewModels
{
    using System.Collections.Generic;
    using Web.ViewModels.Restaurant;

    public class RestaurantMapFilterViewModel
    {
        public int Zoom { get; set; }

        public IEnumerable<RestaurantMapViewModel> Restaurants { get; set; }
    }
}