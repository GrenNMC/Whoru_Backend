using WhoruBackend.Models;
using WhoruBackend.ModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IFeedRepository
    {
        public Task<ResponseView> Create(Feed feed, List<IFormFile> files);
        public Task<Feed?> FindFeedById(int id);
        public Task<ResponseView> Delete(Feed feed);
    }
}
