using WhoruBackend.Models;
using WhoruBackend.ModelViews.NotificationModelView;

namespace WhoruBackend.Repositorys
{
    public interface INotificationRepository
    {
        public Task<List<NotificationModelView>?> GetAllNotification(int idUser);
        public Task CreateNotification(Notification noti);
    }
}
