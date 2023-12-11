using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;

namespace WhoruBackend.Services
{
    public interface IShareService
    {
        public Task<ResponseView> SharePost(int idPost);
        public Task<ResponseView> UnSharePost(int idPost);
        public Task<List<ResponseListUser>?> GetAllUser(int idFeed);
    }
}
