namespace PlacesToEat.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RetaurantUser : User
    {
        [MinLength(1)]
        [MaxLength(150)]
        public string Name { get; set; }

        [MinLength(5)]
        public string Address { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        public double Longitude { get; set; }
    }
}
