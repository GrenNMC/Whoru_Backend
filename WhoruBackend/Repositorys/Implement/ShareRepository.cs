using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class ShareRepository : IShareRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public ShareRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
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
