using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LocationModelView;

namespace WhoruBackend.Repositorys.Implement
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _AppDbContext;
        private readonly IUserInfoRepository _infoRepository;
        public LocationRepository(ApplicationDbContext appDbContext, IUserInfoRepository infoRepository)
        {
            _AppDbContext = appDbContext;
            _infoRepository = infoRepository;
        }

        public Task<List<UserLocationModelView>?> GetNearestUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateLocation(int IdUser, double Long, double Lang)
        {
            try
            {
                var loca = await _AppDbContext.Locations.FirstOrDefaultAsync(s => s.UserId == IdUser);
                if (loca == null)
                {
                    Location location = new Location
                    {
                        UserId = IdUser,
                        Longitude = Long,
                        Latitude = Lang,
                    };
                    _AppDbContext.Locations.Add(location);
                    await _AppDbContext.SaveChangesAsync();
                }
                else
                {
                    loca.Longitude = Long;
                    loca.Latitude = Lang;
                    _AppDbContext.Locations.Update(loca);
                    await _AppDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}
