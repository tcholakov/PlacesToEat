﻿namespace PlacesToEat.Services.Data.Contracts
{
    using System.Linq;

    using PlacesToEat.Data.Models;
    using Tools.Infrastructure.CommonTypes;

    public interface ICategoryService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetFiltered(string search, CategoriesOrderBy order);

        void Create(string name);

        void Delete(int id);

        void Update(int id, string name);

        IQueryable<Category> GetById(int id);
    }
}
