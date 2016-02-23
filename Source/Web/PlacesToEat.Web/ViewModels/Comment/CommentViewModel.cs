namespace PlacesToEat.Web.ViewModels.Comment
{
    using System;
    using AutoMapper;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<PlacesToEat.Data.Models.Comment>, IHaveCustomMappings
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<PlacesToEat.Data.Models.Comment, CommentViewModel>()
                .ForMember(x => x.Author, opts => opts.MapFrom(x => x.Author.FirstName + " " + x.Author.LastName));
        }
    }
}
