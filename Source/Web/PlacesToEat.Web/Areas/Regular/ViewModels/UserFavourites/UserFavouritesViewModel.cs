namespace PlacesToEat.Web.Areas.Regular.ViewModels.UserFavourites
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Tools.Infrastructure.CommonTypes;

    public class UserFavouritesViewModel
    {
        public string Search { get; set; }

        [Display(Name = "Order By")]
        public RestaurantsOrderBy OrderBy { get; set; }

        public IEnumerable<RegularUserFavouriteViewModel> Restaurants { get; set; }
    }
}
