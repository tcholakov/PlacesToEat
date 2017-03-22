namespace PlacesToEat.Web.Areas.Regular.ViewModels.RestaurantFilter
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class RestaurantFilterResponseViewModel
    {
        public string Search { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Distance in km")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double Distance { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
