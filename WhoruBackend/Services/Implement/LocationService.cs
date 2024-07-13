using WhoruBackend.ModelViews.LocationModelView;
using WhoruBackend.Repositorys;

namespace WhoruBackend.Services.Implement
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepo;

        public LocationService(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public async Task CreateNote(int idUser, string Note)
        {
            await _locationRepo.CreateNote(idUser, Note);
        }

        public async Task DeleteNote(int idUser)
        {
            await _locationRepo.DeleteNote(idUser);        
        }

        public async Task<List<UserLocationModelView>?> GetNearestUser(int id, double size, List<int> onlineUser)
        {
            return await _locationRepo.GetNearestUser(id, size, onlineUser);
        }

        public async Task UpdateLocation(int UserId, double Long, double Lang)
        {
            await _locationRepo.UpdateLocation(UserId, Long, Lang);
        }
    }
}
