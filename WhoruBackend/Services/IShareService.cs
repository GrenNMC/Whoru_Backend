using WhoruBackend.ModelViews;

namespace WhoruBackend.Services
{
    public interface IShareService
    {
        public Task<ResponseView> SharePost(int idPost);
        public Task<ResponseView> UnSharePost(int idPost);

    }
}
