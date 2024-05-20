using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class ShareRepository : IShareRepository
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IUserInfoRepository _InfoRepo;
        private readonly IFeedRepository _FeedRepository;
        public ShareRepository(ApplicationDbContext dbContext, IUserInfoRepository infoRepo, IFeedRepository feedRepository)
        {
            _DbContext = dbContext;
            _InfoRepo = infoRepo;
            _FeedRepository = feedRepository;
        }

        public async Task<List<ResponseListUser>?> GetAllUser(int idFeed)
        {
            try
            {
                var listLike = await _DbContext.Shares.Where(s => s.FeedId == idFeed).ToListAsync();
                List<ResponseListUser> listUser = new List<ResponseListUser>();
                if (listLike.Count() > 0)
                {
                    foreach (Share item in listLike)
                    {
                        var info = await _InfoRepo.GetUserInfoById(item.UserId);
                        ResponseListUser user = new ResponseListUser(item.UserId, info.FullName, info.Avatar);
                        listUser.Add(user);
                    }
                    return listUser;
                }
                return null;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return null;
            }
        }

        public async Task<ResponseView> ShareFeed(int idUser, int idFeed)
        {
            try
            {
                var sharePost = await _DbContext.Shares.Where(s => s.UserId == idUser && s.FeedId == idFeed).FirstOrDefaultAsync();
                if (sharePost == null)
                {
                    Share share = new Share
                    {
                        FeedId = idFeed,
                        UserId = idUser,
                        DateTime = DateTime.UtcNow,
                    };
                    _DbContext.Shares.Add(share);
                    await _DbContext.SaveChangesAsync();

                    var receiver = await _FeedRepository.FindFeedById(idFeed);
                    // URL của SignalR hub
                    var hubUrl = "ws://whorubackend20240510001558.azurewebsites.net/notificationHub";

                    // Tạo một kết nối tới hub
                    var connection = new HubConnectionBuilder().WithUrl(hubUrl).Build();
                    // Kết nối tới hub
                    await connection.StartAsync();
                    await connection.InvokeAsync("SendNotification", idUser, receiver.UserInfoId, idUser + " has shared your feed");
                    await connection.StopAsync();

                    return new(MessageConstant.OK);
                }
                return new(MessageConstant.EXISTED);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<ResponseView> UnShareFeed(int idUser, int idFeed)
        {
            try
            {
                var share = await _DbContext.Shares.Where(s => s.UserId == idUser && s.FeedId == idFeed).FirstOrDefaultAsync();
                if (share != null)
                {
                    _DbContext.Shares.Remove(share);
                    await _DbContext.SaveChangesAsync();
                    return new(MessageConstant.OK);
                }
                return new(MessageConstant.NOT_FOUND);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }
    }
}
