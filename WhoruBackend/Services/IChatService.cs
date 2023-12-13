using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.ChatModelViews;

namespace WhoruBackend.Services
{
    public interface IChatService
    {
        public Task SendChat(int Sender, int Receiver, string Message, string Type, bool IsSeen);
        public Task<ResponseView> DeleteChat(int id);
        public Task<List<UserChatModelView>?> GetAllUser();
        public Task<List<ListChatModelView>?> GetAllChat(int idUser);
    }
}
