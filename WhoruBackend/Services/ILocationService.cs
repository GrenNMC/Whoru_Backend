using WhoruBackend.ModelViews.LocationModelView;

namespace WhoruBackend.Services
{
    public interface ILocationService
    {
        public Task UpdateLocation(int UserId, double Long, double Lang);
        public Task<List<UserLocationModelView>?> GetNearestUser(int id);
    }
}
