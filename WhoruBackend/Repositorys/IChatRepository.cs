using WhoruBackend.Models;
using WhoruBackend.ModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IChatRepository
    {
        public Task CreateChat(Chat chat);
        public Task<ResponseView> DeleteChat(int id);

    }
}
