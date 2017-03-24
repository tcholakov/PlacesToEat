namespace PlacesToEat.Web.ViewModels.Restaurant
{
    using System.Collections.Generic;
    using AutoMapper;
    using PlacesToEat.Data.Models.Users;
    using PlacesToEat.Web.Infrastructure.Mapping;
    using RegularUser;

    public class RestaurantBaseViewModel : IMapFrom<RestaurantUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Category { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ICollection<RegularUserViewModel> Favourites { get; set; }

        public virtual void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<RestaurantUser, RestaurantMapViewModel>()
                .ForMember(x => x.Category, opts => opts.MapFrom(x => x.Category == null ? "All" : x.Category.Name));

            configuration.CreateMap<RestaurantUser, RestaurantMapViewModel>()
                .ForMember(x => x.Favourites, opts => opts.MapFrom(x => x.RegularUsers));
        }
    }
}
