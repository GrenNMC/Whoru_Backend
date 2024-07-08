using PagedList;
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

        public async Task<List<ListChatModelView>?> GetAllChat(int idUser, int page)
        {
            int id = await _userService.GetIdByToken();
            int idSender = await _userInfoRepo.GetInfoByUserId(id);
            var listUser = await _chatRepo.GetAllChat(idSender, idUser);
            var result = listUser.ToPagedList(page, 20).ToList();
            ///result.Reverse();
            return result;

        }

        public async Task<List<UserChatModelView>?> GetAllUser(int page)
        {
            int id = await _userService.GetIdByToken();
            int idSender = await _userInfoRepo.GetInfoByUserId(id);
            var listUser = await _chatRepo.GetAllUser(idSender);
            var result = listUser.ToPagedList(page, 10).ToList();
            return result;
        }
        public async Task<List<UserChatModelView>?> GetAllWaitingUser(int page)
        {
            int id = await _userService.GetIdByToken();
            int idSender = await _userInfoRepo.GetInfoByUserId(id);
            var listUser = await _chatRepo.GetAllWaitingUser(idSender);
            var result = listUser.ToPagedList(page, 10).ToList();
            return result;
        }

        public async Task<ListChatModelView> SendChat(int Sender, int Receiver, string Message, string Type, bool IsSeen)
        {
            Chat chat = new Chat
            {
                UserSend = Sender,
                UserReceive = Receiver,
                Message = Message,
                Date = (DateTime.UtcNow).AddHours(7),
                Type = Type,
                IsSeen = IsSeen,
            };
            return await _chatRepo.CreateChat(chat);
        }
    }
}
