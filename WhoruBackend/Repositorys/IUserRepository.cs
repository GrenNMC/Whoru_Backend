using WhoruBackend.Models.dto;
using WhoruBackend.ModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IUserRepository
    {
        public List<UserDto> GetAll();
        public ResponseView Create(RegisterView user);
    }
}
