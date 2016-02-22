namespace PlacesToEat.Web.ViewModels.Category
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ChangeCategoryViewModel
    {
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
