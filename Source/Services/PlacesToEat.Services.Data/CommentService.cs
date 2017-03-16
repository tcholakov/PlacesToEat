namespace PlacesToEat.Services.Data
{
    using Contracts;
    using PlacesToEat.Data.Common;
    using PlacesToEat.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly IDbRepository<Comment> comments;

        public CommentService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void CreateComment(string authorId, string restaurantId, string content)
        {
            var comment = new Comment
            {
                AuthorId = authorId,
                RestaurantId = restaurantId,
                Content = content
            };

            this.comments.Add(comment);

            this.comments.Save();
        }
    }
}
