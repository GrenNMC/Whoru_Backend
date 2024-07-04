using Azure;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.ModelViews.UserModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IUserInfoRepository
    {
        public Task<int> GetInfoByUserId(int userId);
        public Task<UserInfo?> GetUserInfoByName(string userName);
        public Task<UserInfo?> GetUserInfoById(int userId);
        public Task<int> Create(UserInfo user);
        public Task<ResponseView> Update(UserInfo user);
        public Task<List<ResponseListUser>?> SearchUser(string keyWord);
        public Task<ResponseInfoView?> GetUserInfo(int userId, int idAuthor);
        public Task CreateEmbedding(int idUser, double embeddingNumber);
        public Task<List<NumberRecogModelView>?> GetEmbeddedNumber();
        public Task<ResponseView> PostSuggestionFriendList(int idAuth,int type, List<int> idList);
        public Task<List<SuggestUserModelView>?> GetSuggestionFriendList(int idAuth);
    }
}
