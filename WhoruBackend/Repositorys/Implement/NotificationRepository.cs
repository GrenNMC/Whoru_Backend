using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews.NotificationModelView;

namespace WhoruBackend.Repositorys.Implement
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _DbContext;
  
        public NotificationRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task CreateNotification(Notification noti)
        {
            try
            {
                _DbContext.Notifications.Add(noti);
                await _DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        public async Task<List<NotificationModelView>?> GetAllNotification(int idUser)
        {
            try
            {
                List<NotificationModelView> result = new List<NotificationModelView>();
                var list = await _DbContext.Notifications.Where(u => u.UserReceive == idUser).ToListAsync();
                foreach (var notification in list)
                {
                    var info = await _DbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == notification.UserReceive);
                    result.Add(new NotificationModelView(notification.UserReceive.Value, info.Avatar, info.FullName,notification.Date.Value.ToString("H:mm dd/MM/yyyy"),notification.Message));
                }
                if(result.Count != 0)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
            
        }
    }
}
