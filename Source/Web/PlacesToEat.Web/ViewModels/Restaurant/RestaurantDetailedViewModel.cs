namespace PlacesToEat.Web.ViewModels.Restaurant
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Comment;
    using Data.Models.Users;

    public class RestaurantDetailedViewModel : RestaurantBaseViewModel
    {
        public ICollection<CommentViewModel> Comments { get; set; }

        public CommentInputModel CommentInputModel { get; set; }

        public override void CreateMappings(IMapperConfiguration configuration)
        {
            base.CreateMappings(configuration);

            configuration.CreateMap<RestaurantUser, RestaurantDetailedViewModel>()
                .ForMember(x => x.Comments, opts => opts.MapFrom(x => x.Comments.OrderByDescending(c => c.CreatedOn)));

            configuration.CreateMap<RestaurantUser, RestaurantDetailedViewModel>()
                .ForMember(x => x.Favourites, opts => opts.MapFrom(x => x.RegularUsers));
        }
    }
}
