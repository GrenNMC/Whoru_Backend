using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class ShareService : IShareService
    {
        private readonly IShareRepository _shareRepo;
        private readonly IUserService _userService;
        private readonly IFeedRepository _feedRepo;

        public ShareService(IShareRepository shareRepo, IUserService userService, IFeedRepository feedRepo)
        {
            _shareRepo = shareRepo;
            _userService = userService;
            _feedRepo = feedRepo;
        }

        public async Task<List<ResponseListUser>?> GetAllUser(int idFeed)
        {
            return await _shareRepo.GetAllUser(idFeed);
        }

        public async Task<ResponseView> SharePost(int idPost)
        {
            var idUser = await _userService.GetIdByToken();
            var feed = await _feedRepo.FindFeedById(idPost);
            if(feed != null)
            {
                var response = await _shareRepo.ShareFeed(idUser, idPost);
                return new(response.Message);
            }
            return new(MessageConstant.NOT_FOUND);
        }

        public async Task<ResponseView> UnSharePost(int idPost)
        {
            var idUser = await _userService.GetIdByToken();
            var feed = await _feedRepo.FindFeedById(idPost);
            if (feed != null)
            {
                var response = await _shareRepo.UnShareFeed(idUser, idPost);
                return new(response.Message);
            }
            return new(MessageConstant.NOT_FOUND);
        }
    }
}
