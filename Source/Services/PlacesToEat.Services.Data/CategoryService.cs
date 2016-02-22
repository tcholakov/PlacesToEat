namespace PlacesToEat.Services.Data
{
    using System.Linq;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDbRepository<Category> categories;

        public CategoryService(IDbRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All();
        }
    }
}
