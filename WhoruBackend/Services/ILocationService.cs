using WhoruBackend.ModelViews.LocationModelView;

namespace WhoruBackend.Services
{
    public interface ILocationService
    {
        public Task UpdateLocation(int UserId, double Long, double Lang);
        public Task<List<UserLocationModelView>?> GetNearestUser(int id, double size, List<int> onlineUser);
        public Task CreateNote(int idUser, string Note);
        public Task DeleteNote(int idUser);
    }
}
