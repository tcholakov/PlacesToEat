namespace PlacesToEat.Web.Areas.Administration.ViewModels.ListCategories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Tools.Infrastructure.CommonTypes;

    public class AdministerCategoriesViewModel
    {
        public string Search { get; set; }

        [Display(Name = "Order by")]
        public CategoriesOrderBy Order { get; set; }

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
