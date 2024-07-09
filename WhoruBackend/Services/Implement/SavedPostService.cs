using WhoruBackend.ModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class SavedPostService : ISavedPostService
    {
        private readonly ISavedPostRepository _SavedPostRepo;
        private readonly IUserService _userService;
        private readonly IUserInfoRepository _userInfoRepo;

        public SavedPostService(ISavedPostRepository savedPostRepo, IUserService userService, IUserInfoRepository userInfoRepo)
        {
            _SavedPostRepo = savedPostRepo;
            _userService = userService;
            _userInfoRepo = userInfoRepo;
        }

        public async Task<ResponseView> SavedPost(int idPost)
        {
            var idUser = await _userService.GetIdByToken();
            var idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            var response = await _SavedPostRepo.SavedPost(idInfo, idPost);
            return new(response.Message);
        }

        public async Task<ResponseView> UnSavedPost(int idPost)
        {
            var idUser = await _userService.GetIdByToken();
            var idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            var response = await _SavedPostRepo.UnSavedPost(idInfo, idPost);
            return new(response.Message);
        }
    }
}
