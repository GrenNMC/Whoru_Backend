using Azure;
using WhoruBackend.ModelViews;

namespace WhoruBackend.Services
{
    public interface IFeedService
    {
        public Task UploadFeedImage(List<IFormFile> files);
        public Task<ResponseView> Create(int userId, string status);
    }
}
