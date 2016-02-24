namespace PlacesToEat.Web.Areas.Administration.ViewModels.ListCategories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Web.ViewModels.Category;

    public class AdministerCategoriesViewModel
    {
        public string Search { get; set; }

        [Display(Name = "Order by")]
        public OrderType Order { get; set; }

        public string AddUrl
        {
            get
            {
                return "/Administration/AdministerCategories/Add";
            }
        }

        public IEnumerable<CategoryAdvancedViewModel> Categories { get; set; }
    }
}
