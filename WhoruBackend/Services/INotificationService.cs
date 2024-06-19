using WhoruBackend.Controllers;
using WhoruBackend.Models;
using WhoruBackend.ModelViews.NotificationModelView;

namespace WhoruBackend.Services
{
    public interface INotificationService
    {
        public Task<List<NotificationModelView>?> GetAllNotification();
        public Task SendNotification(int Sender, int Receiver, string Notification);
    }
}
