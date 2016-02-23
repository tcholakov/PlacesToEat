namespace PlacesToEat.Web.Areas.Regular.ViewModels.UserFavourites
{
    using AutoMapper;
    using PlacesToEat.Data.Models.Users;
    using PlacesToEat.Web.Infrastructure.Mapping;

    public class RegularUserFavouriteViewModel : IMapFrom<RestaurantUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Category { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int FavouritesCount { get; set; }

        public string Url
        {
            get
            {
                return string.Format("/Restaurant/Details/{0}", this.Id);
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<RestaurantUser, RegularUserFavouriteViewModel>()
                .ForMember(x => x.Category, opts => opts.MapFrom(x => x.Category.Name));

            configuration.CreateMap<RestaurantUser, RegularUserFavouriteViewModel>()
                .ForMember(x => x.FavouritesCount, opts => opts.MapFrom(x => x.RegularUsers.Count));
        }
    }
}
