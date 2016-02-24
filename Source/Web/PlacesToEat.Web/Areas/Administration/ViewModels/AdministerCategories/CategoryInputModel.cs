namespace PlacesToEat.Web.Areas.Administration.ViewModels.AdministerCategories
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
