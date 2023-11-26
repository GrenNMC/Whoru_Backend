using WhoruBackend.ModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IShareRepository
    {
        public Task<ResponseView> ShareFeed(int idUser, int idFeed);
        public Task<ResponseView> UnShareFeed(int idUser, int idFeed);

    }
}
