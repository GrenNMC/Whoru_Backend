using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.CommentModelViews;

namespace WhoruBackend.Services
{
    public interface ICommentService
    {
        public Task<ResponseView> Create(CommentModelView comment);
        public Task<ResponseView> Update(UpdateCommentModelView comment);
        public Task<ResponseView> Delete(int id);
        public Task<Comment?> FindCommentById(int id);
        public Task<List<ResponseAllCommentFromFeed>?> GetAllCommentByFeedId(int id, int page);
    }
}
