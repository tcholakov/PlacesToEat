namespace PlacesToEat.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        [MinLength(3)]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
