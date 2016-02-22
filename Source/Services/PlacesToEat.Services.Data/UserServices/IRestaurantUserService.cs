﻿namespace PlacesToEat.Services.Data.UserServices
{
    using System.Linq;
    using PlacesToEat.Data.Models.Users;

    public interface IRestaurantUserService
    {
        IQueryable<RestaurantUser> GetAll();

        IQueryable<RestaurantUser> GetClosest(double currentLatitude, double currentLongitude, double distanceInKilometeres);
    }
}