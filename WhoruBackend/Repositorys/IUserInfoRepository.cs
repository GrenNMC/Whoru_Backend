using Azure;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IUserInfoRepository
    {
        public Task<int> GetInfoByUserId(int userId);
        public Task<UserInfo?> GetUserInfoByName(string userName);
        public Task<UserInfo?> GetUserInfoById(int userId);
        public Task<ResponseView> Create(UserInfo user);
        public Task<ResponseView> Update(UserInfo user);
    }
}
