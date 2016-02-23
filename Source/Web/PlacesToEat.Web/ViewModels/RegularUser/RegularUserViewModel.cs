namespace PlacesToEat.Web.ViewModels.RegularUser
{
    using Infrastructure.Mapping;

    public class RegularUserViewModel : IMapFrom<PlacesToEat.Data.Models.Users.RegularUser>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
