﻿namespace PlacesToEat.Services.Data
{
    using System.Linq;
    using PlacesToEat.Data.Models.Users;

    public interface IRegularUserService
    {
        IQueryable<RegularUser> GetAll();
    }
}
