namespace PlacesToEat.Web.ViewModels.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class RegisterRestaurantViewModel : RegisterViewModel
    {
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
    }
}