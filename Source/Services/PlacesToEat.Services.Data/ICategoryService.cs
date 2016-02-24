namespace PlacesToEat.Services.Data
{
    using System.Linq;
    using PlacesToEat.Data.Models;

    public interface ICategoryService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetFiltered(string search, int order);

        void Create(string name);

        void Delete(int id);

        void Update(int id, string name);

        IQueryable<Category> GetById(int id);
    }
}
