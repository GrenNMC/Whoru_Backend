using WhoruBackend.ModelViews;

namespace WhoruBackend.Repositorys
{
    public interface ISavedPostRepository
    {
        public Task<ResponseView> SavedPost(int idUser ,int idPost);

        public Task<ResponseView> UnSavedPost(int idUser,int idPost);
    }
}
