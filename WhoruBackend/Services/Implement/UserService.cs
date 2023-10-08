using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Models.dto;
using WhoruBackend.ModelViews;
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

        public ResponseView Create(RegisterView user)
        {
            return _userRepository.Create(user);
        }

        public List<UserDto> GetAll()
        {
            return _userRepository.GetAll();
        }

    }
}
