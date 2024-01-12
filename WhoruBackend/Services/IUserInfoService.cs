using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;

namespace WhoruBackend.Services
{
    public interface IUserInfoService
    {
        public Task<List<ResponseListUser>?> GetUserInfoByName(string userName);
        public Task<ResponseInfoView?> GetUserInfoById(int id);
        public Task<UserInfo?> GetUserInfo(int id);
        public Task<int> Create(RequestUserInfoView request);
        public Task<ResponseView> Update(RequestUserInfoView request);
        public Task<ResponseView> UpdateAvatar(IFormFile file);
        public Task<ResponseView> UpdateBackground(IFormFile file);
    }
}
