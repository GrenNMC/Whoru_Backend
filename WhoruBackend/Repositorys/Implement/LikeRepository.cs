using Firebase.Auth;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.InfoModelViews;
using WhoruBackend.Services;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IUserInfoRepository _UserInfoRepo;
        private readonly IFeedRepository _FeedRepository;
        private readonly INotificationService _notiService;
        public LikeRepository(ApplicationDbContext dbContext, IUserInfoRepository userInfoRepo, IFeedRepository feedRepository, INotificationService service)
        {
            _DbContext = dbContext;
            _UserInfoRepo = userInfoRepo;
            _FeedRepository = feedRepository;
            _notiService = service;
        }

        public async Task<ResponseView> LikeFeed(int idUser ,int idFeed)
        {
            try
            {
                var like = await _DbContext.Likes.Where(s => s.FeedId == idFeed && s.UserId == idUser).FirstOrDefaultAsync();
                if (like == null)
                {
                    var info = await _DbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == idUser);
                    Like likefeed = new Like
                    {
                        FeedId = idFeed,
                        UserId = idUser,
                    };
                    _DbContext.Likes.Add(likefeed);
                    await _DbContext.SaveChangesAsync();
                    var idReceiver = await _FeedRepository.FindFeedById(idFeed);
                    if (idReceiver.UserInfoId.Value != idUser)
                    {
                        // URL của SignalR hub
                        var hubUrl = "wss://whorubackend20240510001558.azurewebsites.net/appHub";
                        //var hubUrl = "wss://localhost:7175/appHub";
                        // Tạo một kết nối tới hub
                        var connection = new HubConnectionBuilder().WithUrl(hubUrl).Build();
                        // Kết nối tới hub
                        await connection.StartAsync();
                        await connection.InvokeAsync("SendNotification", idUser, idReceiver.UserInfoId.Value, info.FullName, info.Avatar, "Like");
                        await connection.StopAsync();
                        await _notiService.SendNotification(idUser, idReceiver.UserInfoId.Value, "Like");
                    }
                    return new(MessageConstant.OK);
                }
                else
                {
                    _DbContext.Likes.Remove(like);
                    await _DbContext.SaveChangesAsync();
                    return new(MessageConstant.OK);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<List<ResponseListUser>?> GetAllUser(int idFeed)
        {
            try
            {
                var listLike = await _DbContext.Likes.Where(s => s.FeedId == idFeed).ToListAsync();
                List<ResponseListUser> listUser = new List<ResponseListUser>();
                if(listLike.Count() > 0)
                {
                    foreach(Like item in listLike)
                    {
                        var info = await _UserInfoRepo.GetUserInfoById(item.UserId);
                        ResponseListUser user = new ResponseListUser(item.UserId,info.FullName,info.Avatar);
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
    }
}
