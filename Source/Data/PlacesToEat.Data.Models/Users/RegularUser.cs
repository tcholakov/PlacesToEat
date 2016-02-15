namespace PlacesToEat.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RegularUser : User
    {
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
