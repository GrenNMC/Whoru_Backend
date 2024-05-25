using Azure;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FeedModelViews;

namespace WhoruBackend.Services
{
    public interface IFeedService
    {
        public Task<ResponseView> Create(int userId, string status, List<IFormFile> files);
        public Task<ResponseView> Delete(int id);
        public Task<List<ResponseAllFeedModelView>?> GetAllFeed(int page);
        public Task<List<ResponseAllFeedModelView>?> GetAllFeedByUserId(int id, int page);
        public Task<List<ResponseAllFeedModelView>?> SearchFeed(string keyWord, int page);
    }
}
