using WhoruBackend.Controllers;
using WhoruBackend.Models;

namespace WhoruBackend.Services
{
    public interface INotificationService
    {
        public Task<List<Notification>?> GetAllNotification();
        public Task SendNotification(int Sender, int Receiver, string Notification);
    }
}
