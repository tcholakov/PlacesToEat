namespace PlacesToEat.Services.Data
{
    public interface ICommentService
    {
        void CreateComment(string authorId, string restaurantId, string content);
    }
}
