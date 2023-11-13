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

        public async Task<ResponseView> Create(int userId, string status)
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
            var newPost = await _feedRepo.Create(feed);
            return newPost;
        }

        public Task UploadFeedImage(List<IFormFile> files)
        {
            throw new NotImplementedException();
        }
    }
}
