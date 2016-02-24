namespace PlacesToEat.Web.Areas.Administration.ViewModels.ListCategories
{
    using Web.ViewModels.Category;

    public class CategoryAdvancedViewModel : CategoryViewModel
    {
        public string DeleteUrl
        {
            get
            {
                return string.Format("/Administration/AdministerCategories/Delete/{0}", this.Id);
            }
        }

        public string UpdateUrl
        {
            get
            {
                return string.Format("/Administration/AdministerCategories/Update/{0}", this.Id);
            }
        }
    }
}
