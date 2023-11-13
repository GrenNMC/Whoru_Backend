using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class FeedRepository : IFeedRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FeedRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseView> Create(Feed feed)
        {
            try
            {
                if (feed == null)
                {
                    return new ResponseView(MessageConstant.NO_DATA_REQUEST);
                }
                await _dbContext.Feeds.AddAsync(feed);
                _dbContext.SaveChanges();
                return new ResponseView(MessageConstant.CREATE_POST_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }
    }
}
