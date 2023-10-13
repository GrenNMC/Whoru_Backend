using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.ModelViews.UserModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IUserRepository
    {
        public List<UserDto> GetAll();
        public ResponseView Create(RegisterView user);
    }
}
