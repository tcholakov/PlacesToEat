namespace PlacesToEat.Web.Areas.Regular.ViewModels.RestaurantFilter
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Web.ViewModels.Restaurant;

    public class RestaurantFilterViewModel
    {
        public string Search { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Distance in km")]
        public double? Distance { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
