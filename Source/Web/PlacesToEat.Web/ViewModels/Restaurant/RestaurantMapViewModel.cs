namespace PlacesToEat.Web.ViewModels.Restaurant
{
    using System;
    using AutoMapper;
    using Data.Models.Users;
    using Infrastructure.Mapping;

    public class RestaurantMapViewModel : RestaurantBaseViewModel
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Url
        {
            get
            {
                return string.Format("/Restaurant/Details/{0}", this.Id);
            }
        }
    }
}
