using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class SavedPostRepository : ISavedPostRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public SavedPostRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<ResponseView> SavedPost(int idUser, int idPost)
        {
            try
            {
                var savePost = await _DbContext.SavedFeeds.Where(s => s.UserId == idUser && s.FeedId == idPost).FirstOrDefaultAsync();
                if (savePost == null)
                {
                    var info = await _DbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == idUser);
                    SavedFeed save = new SavedFeed
                    {
                        FeedId = idPost,
                        UserId = idUser,
                    };
                    _DbContext.SavedFeeds.Add(save);
                    await _DbContext.SaveChangesAsync();
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

        public async Task<ResponseView> UnSavedPost(int idUser, int idPost)
        {
            try
            {
                var save = await _DbContext.SavedFeeds.Where(s => s.UserId == idUser && s.FeedId == idPost).FirstOrDefaultAsync();
                if (save != null)
                {
                    _DbContext.SavedFeeds.Remove(save);
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
