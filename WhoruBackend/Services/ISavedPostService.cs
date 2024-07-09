using WhoruBackend.ModelViews;

namespace WhoruBackend.Services
{
    public interface ISavedPostService
    {
        public Task<ResponseView> SavedPost(int idPost);

        public Task<ResponseView> UnSavedPost(int idPost);

    }
}
