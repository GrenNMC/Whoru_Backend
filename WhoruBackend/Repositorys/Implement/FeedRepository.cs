using Microsoft.EntityFrameworkCore;
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

        public async Task<ResponseView> Create(Feed feed, List<IFormFile> files)
        {
            try
            {
                if (feed == null)
                {
                    return new ResponseView(MessageConstant.NO_DATA_REQUEST);
                }
                _dbContext.Feeds.Add(feed);
                await _dbContext.SaveChangesAsync();

                if(files != null)
                {
                    foreach(var file in files)
                    {
                        UploadImageToStorage storage = new UploadImageToStorage();
                        string url = await storage.FeedImageUrl(file);
                        FeedImage image = new FeedImage
                        {
                            FeedId = feed.Id,
                            Url = url,
                            ImageName = file.FileName,
                        };

                        _dbContext.FeedImages.Add(image);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                return new ResponseView(MessageConstant.CREATE_POST_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<ResponseView> Delete(Feed feed)
        {
            try
            {
                if(feed == null)
                {
                    return new(MessageConstant.NO_DATA_REQUEST);
                }
                List<FeedImage> listImg = _dbContext.FeedImages.Where(s => s.FeedId == feed.Id).ToList();
                if (listImg != null)
                {
                    UploadImageToStorage storage = new UploadImageToStorage();
                    foreach (FeedImage img in listImg)
                    {
                        _ = storage.DeleteFeedImageUrl(img);
                        _dbContext.FeedImages.Remove(img);
                    }
                }
                _dbContext.Feeds.Remove(feed);
                await _dbContext.SaveChangesAsync();
                return new(MessageConstant.DELETE_SUCCESS);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<Feed?> FindFeedById(int id)
        {
            try
            {
                Feed? feed = await _dbContext.Feeds.Where(s => s.Id == id).FirstOrDefaultAsync();
                if (feed == null)
                    return null;
                return feed;
            }
            catch(Exception e) 
            {
                Log.Error(e.Message);
                return null;
            }
        }
    }
}
