using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public LikeRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<ResponseView> LikeFeed(int idUser ,int idFeed)
        {
            try
            {
                var like = await _DbContext.Likes.Where(s => s.FeedId == idFeed && s.UserId == idUser).FirstOrDefaultAsync();
                if (like == null)
                {
                    Like likefeed = new Like
                    {
                        FeedId = idFeed,
                        UserId = idUser,
                    };
                    _DbContext.Likes.Add(likefeed);
                    await _DbContext.SaveChangesAsync();
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
    }
}
