using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LocationModelView;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _AppDbContext;
        public LocationRepository(ApplicationDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public async Task<List<UserLocationModelView>?> GetNearestUser(int id, double size, List<int> onlineUser)
        {
            try
            {
                var listLocation = await _AppDbContext.Locations.Where(s => onlineUser.Contains(s.UserId)).ToListAsync();
                if (listLocation != null) 
                {
                    var userLocation = listLocation.FirstOrDefault(s=> s.UserId == id);
                    if (userLocation == null) 
                    {
                        return null;
                    }
                    List<UserLocationModelView> listResult = new List<UserLocationModelView>();
                    foreach (var location in listLocation)
                    {
                        if(id != location.UserId)
                        {
                                                        //Input: lang1, long1, lang2, long2
                            var distance = LocationCaculator.CalculateDistance(userLocation.Longitude, userLocation.Latitude, location.Longitude, location.Latitude);
                            if (distance < size)
                            {
                                var info = await _AppDbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == location.UserId);
                                UserLocationModelView user = new UserLocationModelView
                                (
                                    location.UserId,
                                    info.Avatar,
                                    location.Latitude,
                                    location.Longitude
                                );
                                listResult.Add (user);
                            }
                        }
                    }
                    if(listResult.Count != 0)
                    {
                        return listResult;
                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
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
