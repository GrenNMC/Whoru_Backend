using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class LikeService : ILikeService
    {
        private readonly IFeedRepository _feedRepo;
        private readonly IUserInfoRepository _infoRepo;
        private readonly IUserService _userService;
        private readonly ILikeRepository _likeRepo;

        public LikeService(IFeedRepository feedRepo, IUserInfoRepository infoRepo, IUserService userService, ILikeRepository likeRepo)
        {
            _feedRepo = feedRepo;
            _infoRepo = infoRepo;
            _userService = userService;
            _likeRepo = likeRepo;
        }

        public async Task<List<ResponseListUser>?> GetAllUser(int idFeed)
        {
            return await _likeRepo.GetAllUser(idFeed);
        }

        public async Task<ResponseView> LikeFeed(int idFeed)
        {
            Feed? feed = await _feedRepo.FindFeedById(idFeed);
            if (feed == null)
            {
                return new ResponseView(MessageConstant.NOT_FOUND);
            }
            var userInfo = await _userService.GetIdByToken();
            var user = await _infoRepo.GetInfoByUserId(userInfo);

            var response = await _likeRepo.LikeFeed(user, idFeed);
            return response;
        }
    }
}
