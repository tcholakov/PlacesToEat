namespace PlacesToEat.Services.Data
{
    using System.Linq;

    using Contracts;
    using PlacesToEat.Data.Common.Contracts;
    using PlacesToEat.Data.Models;
    using Tools.Infrastructure.CommonTypes;

    public class CategoryService : ICategoryService
    {
        private readonly IDbRepository<Category> categories;

        public CategoryService(IDbRepository<Category> categories)
        {
            this.categories = categories;
        }

        public void Create(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.categories.Add(category);

            this.categories.Save();
        }

        public void Delete(int id)
        {
            var itemToDelete = this.categories.GetById(id);

            this.categories.Delete(itemToDelete);

            this.categories.Save();
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All();
        }

        public IQueryable<Category> GetById(int id)
        {
            return this.categories.All().Where(x => x.Id == id);
        }

        public IQueryable<Category> GetFiltered(string search, CategoriesOrderBy order)
        {
            IQueryable<Category> result = this.categories
                                                .All()
                                                .Where(x => x.Name.Contains(search));

            switch (order)
            {
                case CategoriesOrderBy.Id: result = result.OrderBy(x => x.Id);
                    break;
                case CategoriesOrderBy.Name: result = result.OrderBy(x => x.Name);
                    break;
            }

            return result;
        }

        public void Update(int id, string name)
        {
            var category = this.GetById(id).FirstOrDefault();

            if (category != null)
            {
                category.Name = name;

                this.categories.Save();
            }
        }
    }
}
