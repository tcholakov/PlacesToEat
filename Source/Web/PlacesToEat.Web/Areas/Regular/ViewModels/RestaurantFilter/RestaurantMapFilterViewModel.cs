namespace PlacesToEat.Web.Areas.Regular.ViewModels.RestaurantFilter
{
    using System.Collections.Generic;
    using Web.ViewModels.Restaurant;

    public class RestaurantMapFilterViewModel
    {
        public int Zoom { get; set; }

        public IEnumerable<RestaurantMapViewModel> Restaurants { get; set; }
    }
}
