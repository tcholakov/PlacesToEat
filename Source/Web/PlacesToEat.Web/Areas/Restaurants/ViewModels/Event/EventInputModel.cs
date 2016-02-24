namespace PlacesToEat.Web.Areas.Restaurants.ViewModels.Event
{
    using System.ComponentModel.DataAnnotations;

    public class EventInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}