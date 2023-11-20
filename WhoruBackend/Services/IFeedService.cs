using Azure;
using WhoruBackend.ModelViews;

namespace WhoruBackend.Services
{
    public interface IFeedService
    {
        public Task<ResponseView> Create(int userId, string status, List<IFormFile> files);
        public Task<ResponseView> Delete(int id);
    }
}
