using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LocationModelView;

namespace WhoruBackend.Repositorys
{
    public interface ILocationRepository
    {
        public Task UpdateLocation(int IdUser, double Long,double Lang);
        public Task<List<UserLocationModelView>?> GetNearestUser(int id, double size, List<int> onlineUser);
        public Task CreateNote(int idUser, string Note);
        public Task DeleteNote(int idUser);
    }
}
