using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Models.dto;
using WhoruBackend.Repositorys;

namespace WhoruBackend.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Create(UserDto userDto)
        {
            return _userRepository.Create(userDto);
        }

        public List<UserDto> GetAll()
        {
            return _userRepository.GetAll();
        }

    }
}
