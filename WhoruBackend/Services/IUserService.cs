using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.ModelViews.UserModelViews;

namespace WhoruBackend.Services
{
    public interface IUserService
    {
        public List<UserDto> GetAll();
        public ResponseView Create(RegisterView user);
    }
}
