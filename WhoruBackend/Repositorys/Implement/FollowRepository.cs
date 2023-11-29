using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FollowModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class FollowRepository : IFollowRepository
    {
        private readonly IUserInfoRepository _userInfoRepo;
        private readonly ApplicationDbContext _DbContext;
        public FollowRepository(IUserInfoRepository userRepo, ApplicationDbContext dbContext)
        {
            _userInfoRepo = userRepo;
            _DbContext = dbContext;
        }

        public async Task<ResponseView> FollowUser(int idFollower, int idUser)
        {
            try
            {
                var follow = await _DbContext.Follows.Where(s => s.IdFollower == idFollower && s.IdFollowing == idUser).FirstOrDefaultAsync();
                if (follow == null)
                {
                    Follow response = new Follow
                    {
                        IdFollower = idFollower,
                        IdFollowing = idUser,
                    };
                    _DbContext.Follows.Add(response);
                    await _DbContext.SaveChangesAsync();
                    return new(MessageConstant.CREATE_SUCCESS);
                }
                return new(MessageConstant.EXISTED);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<List<FollowerModelView>?> GetAllFollower(int id)
        {
            try
            {
                List<Follow> listFollower = await _DbContext.Follows.Where(s => s.IdFollowing == id).ToListAsync();
                List<FollowerModelView> allFollower = new List<FollowerModelView>();
                if(listFollower == null)
                {
                    return null;
                }

                foreach (var item in listFollower)
                {
                    var user = await _userInfoRepo.GetUserInfoById(item.IdFollower);
                    if(user != null )
                    {
                        FollowerModelView follower = new FollowerModelView(user.Id, user.FullName, user.Avatar);
                        allFollower.Add(follower);
                    }
                }
                return allFollower;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<FollowerModelView>?> GetAllFollowing(int idUser)
        {
            try
            {
                List<Follow> listFollower = await _DbContext.Follows.Where(s => s.IdFollower == idUser).ToListAsync();
                List<FollowerModelView> allFollower = new List<FollowerModelView>();
                if (listFollower == null)
                {
                    return null;
                }

                foreach (var item in listFollower)
                {
                    var user = await _userInfoRepo.GetUserInfoById(item.IdFollowing);
                    if (user != null)
                    {
                        allFollower.Add(new FollowerModelView(user.Id, user.FullName, user.Avatar));
                    }
                }
                return allFollower;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<ResponseView> UnFollowUser(int idFollower, int idUser)
        {
            try
            {
                var follow = await _DbContext.Follows.Where(s => s.IdFollower == idFollower && s.IdFollowing == idUser).FirstOrDefaultAsync();
                if (follow != null)
                {
                    _DbContext.Follows.Remove(follow);
                    await _DbContext.SaveChangesAsync();
                    return new(MessageConstant.DELETE_SUCCESS);
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
