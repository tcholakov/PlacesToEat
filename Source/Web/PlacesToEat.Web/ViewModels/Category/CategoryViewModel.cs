namespace PlacesToEat.Web.ViewModels.Category
{
    using Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<PlacesToEat.Data.Models.Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
