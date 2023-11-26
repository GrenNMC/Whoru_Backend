using WhoruBackend.ModelViews;

namespace WhoruBackend.Services
{
    public interface ILikeService
    {
        public Task<ResponseView> LikeFeed(int idFeed);
    }
}
