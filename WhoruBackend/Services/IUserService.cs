using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Models.dto;
using WhoruBackend.ModelViews;

namespace WhoruBackend.Services
{
    public interface IUserService
    {
        public List<UserDto> GetAll();
        public ResponseView Create(RegisterView user);
    }
}
