namespace PlacesToEat.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRestaurantViewModel : RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [Display(Name = "Restaurant Address")]
        public string Address { get; set; }

        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
