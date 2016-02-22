namespace PlacesToEat.Web.ViewModels.Restaurant
{
    using System;
    using AutoMapper;
    using Data.Models.Users;
    using Infrastructure.Mapping;

    public class RestaurantMapViewModel : RestaurantBaseViewModel
    {
        public string Url
        {
            get
            {
                return string.Format("/Restaurant/Details/{0}", this.Id);
            }
        }
    }
}
