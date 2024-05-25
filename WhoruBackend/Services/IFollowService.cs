using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FollowModelViews;

namespace WhoruBackend.Services
{
    public interface IFollowService
    {
        public Task<ResponseView> FollowUser(int idUser);
        public Task<ResponseView> UnFollowUser(int idUser);
        public Task<List<FollowerModelView>?> GetAllFollower(int page);
        public Task<List<FollowerModelView>?> GetAllFollowing(int page);

    }
}
