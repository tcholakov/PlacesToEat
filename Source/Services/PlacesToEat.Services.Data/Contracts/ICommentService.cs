namespace PlacesToEat.Services.Data.Contracts
{
    public interface ICommentService
    {
        void CreateComment(string authorId, string restaurantId, string content);
    }
}
