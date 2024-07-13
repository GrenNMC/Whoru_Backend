using Azure.Core;
using PagedList;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.ModelViews.UserModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepo;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;

        public UserInfoService(IUserInfoRepository userInfoRepo, IUserService userService, IUserRepository userRepo, IConfiguration config)
        {
            _userInfoRepo = userInfoRepo;
            _userService = userService;
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<int> Create(RequestUserInfoView request)
        {
            if (request == null)
            {
                //return new ResponseView(MessageConstant.NO_DATA_REQUEST);
                return 0;
            }
            int userId = await _userService.GetIdByToken();
            int info = await _userInfoRepo.GetInfoByUserId(userId);
            if(info == -1)
            {
                UserInfo user = new UserInfo
                {
                    FullName = request.FullName,
                    Avatar = _config["Images:DefaultAvatar"],
                    Backround = _config["Images:DefaultBackground"],
                    UserId = userId,
                    Description = request.Description,
                    WorkingAt = request.Work,
                    StudyAt = request.Study,
                    AvtName = _config["Images:DefaultAvtName"],
                    BackroundName = _config["Images:DefaultBgName"],
                };                
                return await _userInfoRepo.Create(user);
            }
            // return new ResponseView(MessageConstant.EXISTED);
            return -1;
        }

        public async Task<List<NumberRecogModelView>?> GetEmbeddedNumber()
        {
            return await _userInfoRepo.GetEmbeddedNumber();
        }

        public async Task<ResponseView> PostSuggestionFriendList(List<int> idList)
        {
            int idUser = await _userService.GetIdByToken();
            int idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            return await _userInfoRepo.PostSuggestionFriendList(idInfo,1, idList);
        }

        public async Task<UserInfoImgModelView?> GetUserInfo(int id)
        {
            var info = await _userInfoRepo.GetUserInfoById(id);
            return new UserInfoImgModelView(info.Avatar, info.FullName);
        }

        public async Task<ResponseInfoView?> GetUserInfoById(int id)
        {
            int idUser = await _userService.GetIdByToken();
            int idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            return await _userInfoRepo.GetUserInfo(id, idInfo);
        }

        public async Task<List<ResponseListUser>?> GetUserInfoByName(string userName, int page)
        {
            var userInfo = await _userInfoRepo.SearchUser(userName);
            var result = userInfo.ToPagedList(page, 10).ToList();
            return result;
        }

        public async Task<ResponseView> Update(RequestUserInfoView request)
        {
            int idUser = await _userService.GetIdByToken();
            User? user = await _userRepo.GetUserById(idUser);
            if (user == null)
            {
                return new(MessageConstant.NOT_FOUND);
            }
            var idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            UserInfo? userInfo = await _userInfoRepo.GetUserInfoById(idInfo);
            if (userInfo == null)
                return new(MessageConstant.NOT_FOUND);

            userInfo.FullName = request.FullName;
            userInfo.Description = request.Description;
            userInfo.WorkingAt = request.Work;
            userInfo.StudyAt = request.Study;

            await _userInfoRepo.Update(userInfo);
            return new(MessageConstant.OK);
        }

        public async Task<ResponseView> UpdateAvatar(IFormFile file)
        {
            int idUser = await _userService.GetIdByToken();
            User? user = await _userRepo.GetUserById(idUser);
            if (user == null)
            {
                return new(MessageConstant.NOT_FOUND);
            }
            var idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            UserInfo? userInfo = await _userInfoRepo.GetUserInfoById(idInfo);
            if (userInfo == null)
                return new(MessageConstant.NOT_FOUND);
            UploadImageToStorage storage = new UploadImageToStorage();
            if(userInfo.AvtName == _config["Images:DefaultAvtName"])
            {
                userInfo.Avatar = await storage.AvatarImageUrl(file);
                userInfo.AvtName = file.FileName;
            }
            else
            {
                await storage.DeleteAvatarImageUrl(userInfo.AvtName);
                userInfo.Avatar = await storage.AvatarImageUrl(file);
                userInfo.AvtName = file.FileName;
            }
            await _userInfoRepo.Update(userInfo);
            return new(MessageConstant.OK);
        }

        public async Task<ResponseView> UpdateBackground(IFormFile file)
        {
            int idUser = await _userService.GetIdByToken();
            User? user = await _userRepo.GetUserById(idUser);
            if (user == null)
            {
                return new(MessageConstant.NOT_FOUND);
            }
            var idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            UserInfo? userInfo = await _userInfoRepo.GetUserInfoById(idInfo);
            if (userInfo == null)
                return new(MessageConstant.NOT_FOUND);
            UploadImageToStorage storage = new UploadImageToStorage();
            if (userInfo.BackroundName == _config["Images:DefaultBgName"])
            {
                userInfo.Backround = await storage.BackgroundImageUrl(file);
                userInfo.BackroundName = file.FileName;
            }
            else
            {
                await storage.DeleteBackgroundImageUrl(userInfo.BackroundName);
                userInfo.Backround = await storage.BackgroundImageUrl(file);
                userInfo.BackroundName = file.FileName;
            }
            await _userInfoRepo.Update(userInfo);
            return new(MessageConstant.OK);
        }

        public async Task<ResponseView> UpdateEmbededNumber(EmbeddingModelView embedding)
        {
            int idUser = await _userService.GetIdByToken();
            int idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            foreach (var item in embedding.Embedded) 
            {
                await _userInfoRepo.CreateEmbedding(idInfo, item);
            }
            return new(MessageConstant.OK);
        }

        public async Task<List<SuggestUserModelView>?> GetSuggestionFriendList()
        {
            int idUser = await _userService.GetIdByToken();
            int idInfo = await _userInfoRepo.GetInfoByUserId(idUser);
            return await _userInfoRepo.GetSuggestionFriendList(idInfo);
        }
    }
}
