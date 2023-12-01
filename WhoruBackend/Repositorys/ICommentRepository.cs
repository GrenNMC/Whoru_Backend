using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.CommentModelViews;

namespace WhoruBackend.Repositorys
{
    public interface ICommentRepository
    {
        public Task<ResponseView> Create(Comment comment);
        public Task<ResponseView> Update(Comment comment);
        public Task<ResponseView> Delete(Comment comment);
        public Task<Comment ?> FindCommentById(int id);
        public Task<List<ResponseAllCommentFromFeed>?> GetAllCommentFromFeed(int feedId);
    }
}
