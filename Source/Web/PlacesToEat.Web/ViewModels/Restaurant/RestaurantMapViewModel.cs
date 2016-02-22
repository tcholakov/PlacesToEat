namespace PlacesToEat.Web.ViewModels.Restaurant
{
    using Data.Models.Users;
    using Infrastructure.Mapping;

    public class RestaurantMapViewModel : IMapFrom<RestaurantUser>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
