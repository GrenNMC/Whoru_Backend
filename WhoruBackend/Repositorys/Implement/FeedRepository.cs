using Firebase.Auth;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
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
                
                var list = await _dbContext.Feeds.ToListAsync();
                //list.Sort((item1, item2) => item1.Date.Value.CompareTo(item2.Date.Value));
                
                if (list != null)
                {
                    List<ResponseAllFeedModelView> listResult = new List<ResponseAllFeedModelView>();
                    foreach (var item in list)
                    {
                        var response = await GetModelView(authUser, item);
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

        private async Task<ResponseAllFeedModelView> GetModelView(int authUser, Feed item)
        {
            bool islike = false;
            bool isShare = false;
            var like = await _dbContext.Likes.Where(s => s.UserId == authUser && s.FeedId == item.Id).FirstOrDefaultAsync();
            if (like != null)
            {
                islike = true;
            }
            var user = await _dbContext.UserInfos.Where(s => s.Id == item.UserInfoId).FirstOrDefaultAsync();
            var listImage = await _dbContext.FeedImages.Where(s => s.FeedId == item.Id).ToListAsync();
            int likeCount = await _dbContext.Likes.Where(s => s.FeedId == item.Id).CountAsync();
            int commentCount = await _dbContext.Comments.Where(s => s.FeedId == item.Id).CountAsync();
            var share = await _dbContext.Shares.Where(s => s.UserId == authUser && s.FeedId == item.Id).FirstOrDefaultAsync();
            if (share != null)
            {
                isShare = true;
            }
            int shareCount = await _dbContext.Shares.Where(s => s.FeedId == item.Id).CountAsync();
            List<string> listImgs = new List<string>();
            if (listImage != null)
            {
                foreach (var image in listImage)
                {
                    listImgs.Add(image.Url);
                }
            }
            ResponseAllFeedModelView response = new ResponseAllFeedModelView(item.Id, item.Status, item.Date.Value.ToString("H:mm dd/MM/yyyy"), listImgs, user.Id, user.FullName, user.Avatar, islike, likeCount, commentCount, isShare, shareCount, item.State);
            return response;
        }
        public async Task<List<ResponseAllFeedModelView>?> GetAllFeedByUserId(int id, int authUser)
        {
            try {
                
                var list = await _dbContext.Feeds.Where(s => s.UserInfoId == id).ToListAsync();
                //var listShared = await _dbContext.Shares.Where(s => s.UserId == id).ToListAsync(); 
                //foreach(var item in listShared)
                //{
                //    var feed = await _dbContext.Feeds.Where(s => s.Id == item.FeedId).FirstOrDefaultAsync();
                //    list.Add(feed);
                //}
                if (list != null)
                {
                    List<ResponseAllFeedModelView> listResult = new List<ResponseAllFeedModelView>();
                    foreach (var item in list)
                    {
                        if(item.State == MessageConstant.PUBLIC)
                        {
                            var response = await GetModelView(authUser, item);
                            listResult.Add(response);
                        }
                        else
                        {
                            if (item.State == MessageConstant.FOLLOWONLY)
                            {
                                var follow = await _dbContext.Follows.FirstOrDefaultAsync(s => s.IdFollower == authUser && s.IdFollowing == item.UserInfoId);
                                if(follow != null)
                                {
                                    var response = await GetModelView(authUser, item);
                                    listResult.Add(response);
                                }
                            }
                            else
                            {
                                if (item.State == MessageConstant.FRIENDONLY)
                                {
                                    var follower = await _dbContext.Follows.FirstOrDefaultAsync(s => s.IdFollower == authUser && s.IdFollowing == item.UserInfoId);
                                    var following = await _dbContext.Follows.FirstOrDefaultAsync(s => s.IdFollower == item.UserInfoId && s.IdFollowing == authUser);
                                    if (follower != null && following != null)
                                    {
                                        var response = await GetModelView(authUser, item);
                                        listResult.Add(response);
                                    }
                                }
                            }
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

        public async Task<List<ResponseAllFeedModelView>?> GetAllSharedPost(int idUser, int authUser)
        {
            try
            {
                var list = new List<Feed>();
                var listShared = await _dbContext.Shares.Where(s => s.UserId == idUser).ToListAsync();
                foreach (var item in listShared)
                {
                    var feed = await _dbContext.Feeds.Where(s => s.Id == item.FeedId).FirstOrDefaultAsync();
                    list.Add(feed);
                }
                if (list != null)
                {
                    List<ResponseAllFeedModelView> listResult = new List<ResponseAllFeedModelView>();
                    foreach (var item in list)
                    {
                        var response = await GetModelView(authUser, item);
                        listResult.Add(response);
                    }
                    return listResult;
                }
                return null;
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<ResponseAllFeedModelView> GetFeedById(int postId, int authUser)
        {
            try
            {
                var feed = await _dbContext.Feeds.FirstOrDefaultAsync(s => s.Id == postId);
                if(feed != null)
                {
                    var response = await GetModelView(authUser, feed);
                    return response;
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
                            var response = await GetModelView(authUser, item);
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

        public async Task<ResponseView> UpdateFeed(Feed feed)
        {
            try
            {
                _dbContext.Feeds.Update(feed);
                await _dbContext.SaveChangesAsync();
                return new(MessageConstant.UPDATE_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }

        }
    }
}
