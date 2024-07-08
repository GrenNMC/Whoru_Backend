using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FeedModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;
using PagedList;
using WhoruBackend.Utilities.Model;

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

        public async Task<ResponseView> Create(int userId, string status, List<IFormFile> files, int state)
        {
            //Model model = new Model();
            //foreach(var file in files)
            //{
            //    var check = model.ClassifyImage(file);
            //    if(check.PredictedLabel != "Neutral")
            //    {
            //        return new ResponseView(MessageConstant.SENSITIVE);
            //    }
            //} 
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
                Date = (DateTime.UtcNow).AddHours(7),
                State = state,
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

        public async Task<List<ResponseAllFeedModelView>?> GetAllFeedByUserId(int id, int page)
        {
            var idUser = await _userService.GetIdByToken();
            int authUser = await _infoRepo.GetInfoByUserId(idUser);

            var list = await _feedRepo.GetAllFeedByUserId(id, authUser);
            var sortedFeeds = list.OrderByDescending(f => f.Date);
            var result = sortedFeeds.ToPagedList(page, 10).ToList();

            return result;
        }

        public async Task<List<ResponseAllFeedModelView>?> GetAllSharedPost(int idUser, int page)
        {
            var id = await _userService.GetIdByToken();
            int authUser = await _infoRepo.GetInfoByUserId(id);
            var list = await _feedRepo.GetAllSharedPost(idUser, authUser);
            var sortedFeeds = list.OrderByDescending(f => f.Date);
            var result = sortedFeeds.ToPagedList(page, 10).ToList();
            return result;
        }

        public async Task<ResponseAllFeedModelView?> GetFeedById(int idPost)
        {
            var idUser = await _userService.GetIdByToken();
            int authUser = await _infoRepo.GetInfoByUserId(idUser);
            var feed = await _feedRepo.GetFeedById(idPost, authUser);
            return feed;
        }

        public async Task<List<ResponseAllFeedModelView>?> SearchFeed(string keyWord, int page)
        {
            var idUser = await _userService.GetIdByToken();
            int authUser = await _infoRepo.GetInfoByUserId(idUser);
            var list = await _feedRepo.SearchFeed(keyWord, authUser);
            var result = list.ToPagedList(page, 10).ToList();
            return result;
        }

  
        public async Task<ResponseView> UpdateFeedStatus(int IdPost, int Status)
        {
            var feed = await _feedRepo.FindFeedById(IdPost);
            if (feed != null) {
                feed.State =  Status;
                var response = await _feedRepo.UpdateFeed(feed);
                return response;
            }
            return new ResponseView(MessageConstant.NO_DATA_REQUEST);
        }
    }
}
