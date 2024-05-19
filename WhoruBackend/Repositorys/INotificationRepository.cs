using WhoruBackend.Models;

namespace WhoruBackend.Repositorys
{
    public interface INotificationRepository
    {
        public Task<List<Notification>?> GetAllNotification(int idUser);
        public Task CreateNotification(Notification noti);
    }
}
