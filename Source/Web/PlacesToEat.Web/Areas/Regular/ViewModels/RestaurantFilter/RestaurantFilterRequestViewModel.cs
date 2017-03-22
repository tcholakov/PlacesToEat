namespace PlacesToEat.Web.Areas.Regular.ViewModels.RestaurantFilter
{
    public class RestaurantFilterRequestViewModel
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Search { get; set; }

        public int CategoryId { get; set; }

        public double? Distance { get; set; }
    }
}
