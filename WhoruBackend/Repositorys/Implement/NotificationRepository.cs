using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using WhoruBackend.Data;
using WhoruBackend.Models;

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

        public async Task<List<Notification>?> GetAllNotification(int idUser)
        {
            return await _DbContext.Notifications.Where(u => u.UserReceive ==  idUser).ToListAsync();
        }
    }
}
