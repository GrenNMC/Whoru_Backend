using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.StoryModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IStoryRepository
    {
        public Task<ResponseView> Create(Story story);
        public Task<List<StoryModelView>?> GetStoryByUserId(int id);
        public Task<Story?> GetStoryById(int id);
        public Task<ResponseView> Delete(int id);
    }
}
