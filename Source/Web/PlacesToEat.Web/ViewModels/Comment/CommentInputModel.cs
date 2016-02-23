namespace PlacesToEat.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
