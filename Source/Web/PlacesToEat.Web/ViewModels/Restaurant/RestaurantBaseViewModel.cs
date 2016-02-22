﻿namespace PlacesToEat.Web.ViewModels.Restaurant
{
    using AutoMapper;
    using PlacesToEat.Data.Models.Users;
    using PlacesToEat.Web.Infrastructure.Mapping;

    public class RestaurantBaseViewModel : IMapFrom<RestaurantUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Category { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int FavouritedBy { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<RestaurantUser, RestaurantMapViewModel>()
                .ForMember(x => x.Category, opts => opts.MapFrom(x => x.Category.Name));

            configuration.CreateMap<RestaurantUser, RestaurantMapViewModel>()
                .ForMember(x => x.FavouritedBy, opts => opts.MapFrom(x => x.RegularUsers.Count));
        }
    }
}