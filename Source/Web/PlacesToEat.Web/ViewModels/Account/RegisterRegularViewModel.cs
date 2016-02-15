namespace PlacesToEat.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRegularViewModel : RegisterViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}
