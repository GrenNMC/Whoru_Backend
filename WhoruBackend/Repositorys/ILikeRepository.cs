using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;

namespace WhoruBackend.Repositorys
{
    public interface ILikeRepository
    {
        public Task<ResponseView> LikeFeed(int idUser ,int idFeed);
        public Task<List<ResponseListUser>?> GetAllUser(int idFeed);
    }
}
