using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.StoryModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class StoryRepository : IStoryRepository
    {
        private readonly ApplicationDbContext _Dbcontext;
        private readonly IFollowRepository _FollowRepository;
        private readonly IUserInfoRepository _UserInfoRepository;
        public StoryRepository(ApplicationDbContext dbcontext, IFollowRepository followRepository, IUserInfoRepository userInfoRepository)
        {
            _Dbcontext = dbcontext;
            _FollowRepository = followRepository;
            _UserInfoRepository = userInfoRepository;
        }

        public async Task<ResponseView> Create(Story story)
        {
            try
            {
                 _Dbcontext.Stories.Add(story);  
                await _Dbcontext.SaveChangesAsync();
                return new ResponseView(MessageConstant.CREATE_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<ResponseView> Delete(int id)
        {
            try
            {
                Story? story = await _Dbcontext.Stories.Where(s => s.Id == id).FirstOrDefaultAsync();
                if (story == null)
                {
                    return new(MessageConstant.NOT_FOUND);
                }
                
                UploadImageToStorage storage = new UploadImageToStorage();
                await storage.DeleteStoryImageUrl(story.Name);
                _Dbcontext.Stories.Remove(story);
                await _Dbcontext.SaveChangesAsync();
                return new(MessageConstant.DELETE_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<Story?> GetStoryById(int id)
        {
            try
            {
                var story = await _Dbcontext.Stories.FirstOrDefaultAsync(s => s.Id == id);
                if (story == null)
                    return null;
                return story;
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<StoryModelView>?> GetStoryByUserId(int id)
        {
            try
            {
                var story = await _Dbcontext.Stories.Where(s => s.UserId == id).ToListAsync();
                var following = await _FollowRepository.GetAllFollowing(id);
                if(following != null)
                {
                    foreach (var item in following)
                    {
                        var followingStories = await _Dbcontext.Stories.Where(s => s.UserId == item.id).ToListAsync();
                        story = story.Concat(followingStories).ToList();
                    }
                }
                var list = story.OrderByDescending(s => s.Date);
                List<StoryModelView> Results = new List<StoryModelView>();
                foreach(var item in list)
                {
                    var info = await _UserInfoRepository.GetUserInfoById((int)item.UserId);
                    Results.Add(new StoryModelView(item.UserId.Value, info.FullName, info.Avatar, item.ImageUrl, item.Date.Value.ToString("H:mm dd/MM/yyyy")));
                }
                return Results;
            }
            catch(Exception ex) 
            {
                Log.Error(ex.Message);
                return null;
            }
        }
    }
}
