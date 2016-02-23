namespace PlacesToEat.Web.Areas.Regular.ViewModels.UserFavourites
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserFavouritesViewModel
    {
        public string Search { get; set; }

        [Display(Name = "Order By")]
        public OrderByType OrderBy { get; set; }

        public IEnumerable<RegularUserFavouriteViewModel> Restaurants { get; set; }
    }
}
