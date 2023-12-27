using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.ChatModelViews;
using WhoruBackend.Repositorys;

namespace WhoruBackend.Services.Implement
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepo;
        private readonly IUserService _userService;
        private readonly IUserInfoRepository _userInfoRepo;
        public ChatService(IChatRepository chatRepo, IUserService userService, IUserInfoRepository userInfo)
        {
            _chatRepo = chatRepo;
            _userService = userService;
            _userInfoRepo = userInfo;
        }

        public Task<ResponseView> DeleteChat(int id)
        {
            return _chatRepo.DeleteChat(id);
        }

        public async Task<List<ListChatModelView>?> GetAllChat(int idUser)
        {
            int id = await _userService.GetIdByToken();
            int idSender = await _userInfoRepo.GetInfoByUserId(id);
            return await _chatRepo.GetAllChat(idSender, idUser);
        }

        public async Task<List<UserChatModelView>?> GetAllUser()
        {
            int id = await _userService.GetIdByToken();
            return await _chatRepo.GetAllUser(id);
        }

        public async Task SendChat(int Sender, int Receiver, string Message, string Type, bool IsSeen)
        {
            Chat chat = new Chat
            {
                UserSend = Sender,
                UserReceive = Receiver,
                Message = Message,
                Date = DateTime.UtcNow,
                Type = Type,
                IsSeen = IsSeen,
            };
            await _chatRepo.CreateChat(chat);
        }
    }
}
