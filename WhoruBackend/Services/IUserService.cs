using Microsoft.AspNetCore.Mvc;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.ModelViews.UserModelViews;

namespace WhoruBackend.Services
{
    public interface IUserService
    {
        public Task<List<UserDto>?> GetAll();
        public Task<ResponseView> Create(RegisterView user);
        public Task<int> GetIdByToken();
    }
}
