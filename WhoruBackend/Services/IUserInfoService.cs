using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.ModelViews.UserModelViews;

namespace WhoruBackend.Services
{
    public interface IUserInfoService
    {
        public Task<List<ResponseListUser>?> GetUserInfoByName(string userName, int page);
        public Task<ResponseInfoView?> GetUserInfoById(int id);
        public Task<UserInfo?> GetUserInfo(int id);
        public Task<int> Create(RequestUserInfoView request);
        public Task<ResponseView> Update(RequestUserInfoView request);
        public Task<ResponseView> UpdateAvatar(IFormFile file);
        public Task<ResponseView> UpdateBackground(IFormFile file);
        public Task<ResponseView> UpdateEmbededNumber(EmbeddingModelView embedding);
        public Task<List<NumberRecogModelView>?> GetEmbeddedNumber();
        public Task<List<SuggestUserModelView>?> GetSuggestionFriendList(List<int> idList);
    }
}
