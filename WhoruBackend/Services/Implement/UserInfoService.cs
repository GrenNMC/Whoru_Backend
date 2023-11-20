using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepo;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepo;

        public UserInfoService(IUserInfoRepository userInfoRepo, IUserService userService, IUserRepository userRepo)
        {
            _userInfoRepo = userInfoRepo;
            _userService = userService;
            _userRepo = userRepo;
        }

        public async Task<ResponseView> Create(RequestUserInfoView request)
        {
            if (request == null)
            {
                return new ResponseView(MessageConstant.NO_DATA_REQUEST);
            }
            int userId = await _userService.GetIdByToken();
            int info = await _userInfoRepo.GetInfoByUserId(userId);
            if(info == -1)
            {
                UserInfo user = new UserInfo
                {
                    FullName = request.FullName,
                    Avatar = request.Avatar,
                    Backround = request.Backround,
                    UserId = userId,
                };                
                return await _userInfoRepo.Create(user);
            }
            return new ResponseView(MessageConstant.EXISTED);
        }

        public async Task<UserInfo?> GetUserInfoByName(string userName)
        {
            return await _userInfoRepo.GetUserInfoByName(userName);
        }

        public async Task<ResponseView> Update(RequestUserInfoView request)
        {
            int idUser = await _userService.GetIdByToken();
            User? user = await _userRepo.GetUserById(idUser);
            if (user == null)
            {
                return new(MessageConstant.NOT_FOUND);
            }
            UserInfo? userInfo = await _userInfoRepo.GetUserInfoByName(user.UserName);
            if (userInfo == null)
                return new(MessageConstant.NOT_FOUND);
            userInfo.Avatar = request.Avatar;
            userInfo.Backround = request.Backround;
            userInfo.FullName = request.FullName;

            var response = await _userInfoRepo.Update(userInfo);
            return response;
        }
    }
}
