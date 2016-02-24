namespace PlacesToEat.Web.ViewModels.Event
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Infrastructure.Mapping;
    using RegularUser;

    public class EventViewModel : IMapFrom<PlacesToEat.Data.Models.Event>, IHaveCustomMappings
    {
        public string RestaurantId { get; set; }

        public string Restaurant { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<RegularUserViewModel> Participants { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<PlacesToEat.Data.Models.Event, EventViewModel>()
                .ForMember(x => x.Restaurant, opts => opts.MapFrom(x => x.Restaurant.Name));
        }
    }
}
