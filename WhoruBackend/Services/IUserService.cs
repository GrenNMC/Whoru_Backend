using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Models.dto;

namespace WhoruBackend.Services
{
    public interface IUserService
    {
        public List<UserDto> GetAll();
        public UserDto Create(UserDto userDto);
    }
}
