using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FollowModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepo;
        private readonly IUserInfoRepository _userInfoRepo;
        private readonly IUserService _userService;
        public FollowService(IFollowRepository followRepo, IUserInfoRepository userInfoRepo, IUserService userService)
        {
            _followRepo = followRepo;
            _userInfoRepo = userInfoRepo;
            _userService = userService;
        }

        public async Task<ResponseView> FollowUser(int idUser)
        {
            int follower = await _userService.GetIdByToken();
            int idFollower = await _userInfoRepo.GetInfoByUserId(follower);
            int idUserInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            if (follower < 0 || idFollower < 0 || idUserInfo < 0)
            {
                return new ResponseView(MessageConstant.NOT_FOUND);
            }

            var response = await _followRepo.FollowUser(idFollower, idUserInfo);
            return response;
        }

        public async Task<List<FollowerModelView>?> GetAllFollower()
        {
            int idUser = await _userService.GetIdByToken();
            int id = await _userInfoRepo.GetInfoByUserId(idUser);
            List<FollowerModelView>? list = await _followRepo.GetAllFollower(id);
            if(list == null)
            {
                return null;
            }
            return list;
        }

        public async Task<List<FollowerModelView>?> GetAllFollowing()
        {
            int idUser = await _userService.GetIdByToken();
            int id = await _userInfoRepo.GetInfoByUserId(idUser);
            List<FollowerModelView>? list = await _followRepo.GetAllFollowing(id);
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public async Task<ResponseView> UnFollowUser(int idUser)
        {
            int follower = await _userService.GetIdByToken();
            int idFollower = await _userInfoRepo.GetInfoByUserId(follower);
            int idUserInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            if (follower < 0 || idFollower < 0 || idUserInfo < 0)
            {
                return new ResponseView(MessageConstant.NOT_FOUND);
            }

            var response = await _followRepo.UnFollowUser(idFollower, idUserInfo);
            return response;
        }
    }
}
