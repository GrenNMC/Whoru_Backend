using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FollowModelViews;

namespace WhoruBackend.Services
{
    public interface IFollowService
    {
        public Task<ResponseView> FollowUser(int idUser);
        public Task<ResponseView> UnFollowUser(int idUser);
        public Task<List<FollowerModelView>?> GetAllFollower();
        public Task<List<FollowerModelView>?> GetAllFollowing();

    }
}
