using Azure;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IUserInfoRepository
    {
        public Task<int> GetInfoByUserId(int userId);
        public Task<UserInfo?> GetUserInfoByName(string userName);
        public Task<UserInfo?> GetUserInfoById(int userId);
        public Task<ResponseView> Create(UserInfo user);
        public Task<ResponseView> Update(UserInfo user);
        public Task<List<ResponseListUser>?> SearchUser(string keyWord);
        public Task<ResponseInfoView?> GetUserInfo(int userId, int idAuthor);
    }
}
