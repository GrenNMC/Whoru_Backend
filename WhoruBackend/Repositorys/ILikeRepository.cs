using WhoruBackend.ModelViews;

namespace WhoruBackend.Repositorys
{
    public interface ILikeRepository
    {
        public Task<ResponseView> LikeFeed(int idUser ,int idFeed);
    }
}
