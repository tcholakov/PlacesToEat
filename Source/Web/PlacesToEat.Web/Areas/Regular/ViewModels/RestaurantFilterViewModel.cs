namespace PlacesToEat.Web.Areas.Regular.ViewModels
{
    using Web.ViewModels.Restaurant;

    public class RestaurantFilterViewModel
    {
        public string Search { get; set; }

        public int? CategoryId { get; set; }

        public double? Distance { get; set; }

        public RestaurantMapViewModel RestaurantMapViewModel { get; set; }
    }
}
