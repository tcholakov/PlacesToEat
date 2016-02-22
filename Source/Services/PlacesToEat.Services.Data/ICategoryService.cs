namespace PlacesToEat.Services.Data
{
    using System.Linq;
    using PlacesToEat.Data.Models;

    public interface ICategoryService
    {
        IQueryable<Category> GetAll();
    }
}
