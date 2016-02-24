namespace PlacesToEat.Web.Areas.Administration.ViewModels.AdministerCategories
{
    using PlacesToEat.Data.Models;
    using PlacesToEat.Web.Infrastructure.Mapping;

    public class CategoryUpdateInputModel : CategoryInputModel, IMapFrom<Category>
    {
        public int Id { get; set; }
    }
}
