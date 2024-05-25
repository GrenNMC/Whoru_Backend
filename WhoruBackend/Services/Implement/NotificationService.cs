using WhoruBackend.Models;
using WhoruBackend.Repositorys;

namespace WhoruBackend.Services.Implement
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository  _notificationRepo;
        private readonly IUserService _userService;
        private readonly IUserInfoRepository _userRepository;
        public NotificationService(INotificationRepository notificationRepo, IUserService userService, IUserInfoRepository userInfoRepository)
        {
            _notificationRepo = notificationRepo;
            _userService = userService;
            _userRepository = userInfoRepository;
        }

        public async Task<List<Notification>?> GetAllNotification()
        {
            var idUser = await _userService.GetIdByToken();
            var id = await _userRepository.GetInfoByUserId(idUser);
            return await _notificationRepo.GetAllNotification(id);  
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
