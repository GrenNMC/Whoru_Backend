using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;
using PagedList;

namespace WhoruBackend.Services.Implement
{
    public class FeedService : IFeedService
    {
        private readonly IFeedRepository _feedRepo;
        private readonly IUserInfoRepository _infoRepo;
        private readonly IUserService _userService;

        public FeedService(IFeedRepository feedRepo, IUserInfoRepository infoRepo, IUserService userService)
        {
            _feedRepo = feedRepo;
            _infoRepo = infoRepo;
            _userService = userService;
        }

        public async Task<ResponseView> Create(int userId, string status, List<IFormFile> files)
        {
            if(status == null)
            {
                return new ResponseView(MessageConstant.NO_DATA_REQUEST);
            }
            int infoId = await _infoRepo.GetInfoByUserId(userId);
            Feed feed = new Feed
            {
                Status = status,
                UserId = userId,
                UserInfoId = infoId,
                Date = DateTime.UtcNow,
            };
            var newPost = await _feedRepo.Create(feed, files);
            return newPost;
        }

        public async Task<ResponseView> Delete(int id)
        {
            Feed? feed = await _feedRepo.FindFeedById(id);
            if(feed == null)
            {
                return new(MessageConstant.NOT_FOUND);
            }
            var response = await _feedRepo.Delete(feed);
            return response;
        }

        public async Task<List<ResponseAllFeedModelView>?> GetAllFeed(int page)
        {
            int pageSize = 10;
            var id = await _userService.GetIdByToken();
            int authUser = await _infoRepo.GetInfoByUserId(id);
            var listFeed = await _feedRepo.GetAllFeed(authUser);

            var sortedFeeds = listFeed.OrderByDescending(f => f.Date)
                               .ThenByDescending(f => f.LikesCount);

            var result = sortedFeeds.ToPagedList(page, pageSize).ToList();

            return result;
        }

        public async Task<List<ResponseAllFeedModelView>?> GetAllFeedByUserId(int id)
        {
            var idUser = await _userService.GetIdByToken();
            int authUser = await _infoRepo.GetInfoByUserId(idUser);
            return await _feedRepo.GetAllFeedByUserId(id, authUser);
        }

        public async Task<List<ResponseAllFeedModelView>?> SearchFeed(string keyWord)
        {
            var idUser = await _userService.GetIdByToken();
            int authUser = await _infoRepo.GetInfoByUserId(idUser);
            return await _feedRepo.SearchFeed(keyWord, authUser);
        }
    }
}
