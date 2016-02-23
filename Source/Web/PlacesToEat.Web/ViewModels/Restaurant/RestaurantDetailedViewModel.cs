namespace PlacesToEat.Web.ViewModels.Restaurant
{
    using System.Collections.Generic;
    using Comment;

    public class RestaurantDetailedViewModel : RestaurantBaseViewModel
    {
        public ICollection<CommentViewModel> Comments { get; set; }

        public CommentInputModel CommentInputModel { get; set; }
    }
}
