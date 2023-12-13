using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.ChatModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IChatRepository
    {
        public Task CreateChat(Chat chat);
        public Task<ResponseView> DeleteChat(int id);
        public Task<List<UserChatModelView>?> GetAllUser(int idUser);
        public Task<List<ListChatModelView>?> GetAllChat(int idSender, int idReceiver);

    }
}
