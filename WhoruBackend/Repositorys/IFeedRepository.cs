using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FeedModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IFeedRepository
    {
        public Task<ResponseView> Create(Feed feed, List<IFormFile> files);
        public Task<Feed?> FindFeedById(int id);
        public Task<ResponseView> Delete(Feed feed);
        public Task<List<ResponseAllFeedModelView>?> GetAllFeed(int authUser);
        public Task<List<ResponseAllFeedModelView>?> GetAllFeedByUserId(int id,int authUser);
        public Task<List<ResponseAllFeedModelView>?> GetAllSharedPost(int idUser, int authUser);
        public Task<List<ResponseAllFeedModelView>?> GetAllSavePost(int idUser, int authUser);
        public Task<List<ResponseAllFeedModelView>?> SearchFeed(string keyWord, int authUser);
        public Task<ResponseAllFeedModelView> GetFeedById(int postId, int authUser);
        public Task<ResponseView> UpdateFeed(Feed feed); 
    }
}
