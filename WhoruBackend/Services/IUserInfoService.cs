using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;

namespace WhoruBackend.Services
{
    public interface IUserInfoService
    {
        public Task<UserInfo?> GetUserInfoByName(string userName);
        public Task<ResponseView> Create(RequestUserInfoView request);
        public Task<ResponseView> Update(RequestUserInfoView request);
    }
}
