using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.ChatModelViews;

namespace WhoruBackend.Services
{
    public interface IChatService
    {
        public Task<ListChatModelView> SendChat(int Sender, int Receiver, string Message, string Type, bool IsSeen);
        //public Task SendWaitChat(int Sender, int Receiver, string Message, string Type, bool IsSeen);
        public Task<ResponseView> DeleteChat(int id);
        public Task<List<UserChatModelView>?> GetAllUser(int page);
        public Task<List<UserChatModelView>?> GetAllWaitingUser(int page);
        public Task<List<ListChatModelView>?> GetAllChat(int idUser,int page);

    }
}
