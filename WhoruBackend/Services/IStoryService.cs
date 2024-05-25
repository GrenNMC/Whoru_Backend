using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.StoryModelViews;

namespace WhoruBackend.Services
{
    public interface IStoryService
    {
        public Task<ResponseView> Create(IFormFile file);
        public Task<ResponseView> Delete(int id);
        public Task<List<StoryModelView>?> GetAllByUserId(int page);
    }
}
