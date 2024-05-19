using WhoruBackend.Models;
using WhoruBackend.Repositorys;

namespace WhoruBackend.Services.Implement
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository  _notificationRepo;
        private readonly IUserService _userService;

        public NotificationService(INotificationRepository notificationRepo, IUserService userService)
        {
            _notificationRepo = notificationRepo;
            _userService = userService;
        }

        public async Task<List<Notification>?> GetAllNotification()
        {
            var idUser = await _userService.GetIdByToken();
            return await _notificationRepo.GetAllNotification(idUser);  
        }

        public async Task SendNotification(int Sender, int Receiver, string Notification)
        {
            Notification noti = new Notification
             {
                UserSend = Sender,
                UserReceive = Receiver,
                Date = DateTime.Now,
                Message = Notification
            };
            await _notificationRepo.CreateNotification(noti);
        }
    }
}
