using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FeedModelViews;
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

        public async Task<List<ResponseAllFeedModelView>?> GetAllFeed(int authUser)
        {
            try {
                List<ResponseAllFeedModelView> listResult = new List<ResponseAllFeedModelView> ();
               
                var list = await _dbContext.Feeds.ToListAsync();
                //list.Sort((item1, item2) => item1.Date.Value.CompareTo(item2.Date.Value));
                
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        bool islike = false;
                        var user = await _dbContext.UserInfos.Where(s => s.Id == item.UserInfoId).FirstOrDefaultAsync();
                        var listImage = await _dbContext.FeedImages.Where(s => s.FeedId == item.Id).ToListAsync();
                        var like = await _dbContext.Likes.Where(s => s.UserId == authUser && s.FeedId == item.Id).FirstOrDefaultAsync();
                        if (like != null)
                        {
                            islike = true;
                        }
                        int likeCount = await _dbContext.Likes.Where(s => s.FeedId == item.Id).CountAsync();
                        int commentCount = await _dbContext.Comments.Where(s => s.FeedId == item.Id).CountAsync();
                        int shareCount = await _dbContext.Shares.Where(s => s.FeedId == item.Id).CountAsync();
                        List<string> listImgs = new List<string>();
                        if (listImage != null) {
                            foreach (var image in listImage)
                            {
                                listImgs.Add(image.Url);
                            }
                        }
                        ResponseAllFeedModelView response = new ResponseAllFeedModelView(item.Id,item.Status,listImgs,user.Id,user.FullName,user.Avatar,islike,likeCount,commentCount,shareCount);
                        listResult.Add(response);
                    }
                    return listResult;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<ResponseAllFeedModelView>?> GetAllFeedByUserId(int id, int authUser)
        {
            try {
                List<ResponseAllFeedModelView> listResult = new List<ResponseAllFeedModelView>();

                var list = await _dbContext.Feeds.Where(s => s.UserId == id).ToListAsync();

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        bool islike = false;
                        var like = await _dbContext.Likes.Where(s => s.UserId == authUser && s.FeedId == item.Id).FirstOrDefaultAsync();
                        if (like != null)
                        {
                            islike = true;
                        }
                        var user = await _dbContext.UserInfos.Where(s => s.Id == item.UserInfoId).FirstOrDefaultAsync();
                        var listImage = await _dbContext.FeedImages.Where(s => s.FeedId == item.Id).ToListAsync();
                        int likeCount = await _dbContext.Likes.Where(s => s.FeedId == item.Id).CountAsync();
                        int commentCount = await _dbContext.Comments.Where(s => s.FeedId == item.Id).CountAsync();
                        int shareCount = await _dbContext.Shares.Where(s => s.FeedId == item.Id).CountAsync();
                        List<string> listImgs = new List<string>();
                        if (listImage != null)
                        {
                            foreach (var image in listImage)
                            {
                                listImgs.Add(image.Url);
                            }
                        }
                        ResponseAllFeedModelView response = new ResponseAllFeedModelView(item.Id, item.Status, listImgs, user.Id, user.FullName, user.Avatar,islike, likeCount, commentCount, shareCount);
                        listResult.Add(response);
                    }
                    return listResult;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<ResponseAllFeedModelView>?> SearchFeed(string keyWord, int authUser)
        {
            try
            {
                List<ResponseAllFeedModelView> listResult = new List<ResponseAllFeedModelView>();

                var list = await _dbContext.Feeds.ToListAsync();

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        if (item.Status.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            bool islike = false;
                            var like = await _dbContext.Likes.Where(s => s.UserId == authUser && s.FeedId == item.Id).FirstOrDefaultAsync();
                            if (like != null)
                            {
                                islike = true;
                            }
                            var user = await _dbContext.UserInfos.Where(s => s.Id == item.UserInfoId).FirstOrDefaultAsync();
                            var listImage = await _dbContext.FeedImages.Where(s => s.FeedId == item.Id).ToListAsync();
                            int likeCount = await _dbContext.Likes.Where(s => s.FeedId == item.Id).CountAsync();
                            int commentCount = await _dbContext.Comments.Where(s => s.FeedId == item.Id).CountAsync();
                            int shareCount = await _dbContext.Shares.Where(s => s.FeedId == item.Id).CountAsync();
                            List<string> listImgs = new List<string>();
                            if (listImage != null)
                            {
                                foreach (var image in listImage)
                                {
                                    listImgs.Add(image.Url);
                                }
                            }
                            ResponseAllFeedModelView response = new ResponseAllFeedModelView(item.Id, item.Status, listImgs, user.Id, user.FullName, user.Avatar, islike, likeCount, commentCount, shareCount);
                            listResult.Add(response);
                        }
                    }
                    return listResult;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }
    }
}
