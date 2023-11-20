using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Services.Implement
{
    public class FeedService : IFeedService
    {
        private readonly IFeedRepository _feedRepo;
        private readonly IUserInfoRepository _infoRepo;

        public FeedService(IFeedRepository feedRepo, IUserInfoRepository infoRepo)
        {
            _feedRepo = feedRepo;
            _infoRepo = infoRepo;
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
    }
}
