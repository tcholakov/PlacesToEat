namespace PlacesToEat.Web.Infrastructure.ListGenerators
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ViewModels.Category;

    public static class DropDownListGenerator
    {
        public static IEnumerable<SelectListItem> GetCategorySelectListItems(IEnumerable<CategoryViewModel> categories)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var category in categories)
            {
                selectList.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }

            return selectList;
        }
    }
}
