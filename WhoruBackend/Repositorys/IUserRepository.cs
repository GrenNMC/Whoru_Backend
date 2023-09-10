using WhoruBackend.Models.dto;

namespace WhoruBackend.Repositorys
{
    public interface IUserRepository
    {
        public List<UserDto> GetAll();
        public UserDto Create(UserDto userDto);
    }
}
