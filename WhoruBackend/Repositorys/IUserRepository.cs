using System.Runtime.CompilerServices;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.ModelViews.UserModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IUserRepository
    {
        public Task<List<UserDto>?> GetAll();
        public Task<ResponseView> Create(User user);
        public Task UpdateUser(User user);
        public Task<User?> GetUserByName(string name);
        public Task<User?> GetUserById(int id);
    }
}
