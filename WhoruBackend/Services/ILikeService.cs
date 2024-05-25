using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;

namespace WhoruBackend.Services
{
    public interface ILikeService
    {
        public Task<ResponseView> LikeFeed(int idFeed);
        public Task<List<ResponseListUser>?> GetAllUser(int idFeed, int page);
    }
}
