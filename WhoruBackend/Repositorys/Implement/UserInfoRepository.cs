using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.Utilities.Constants;

namespace WhoruBackend.Repositorys.Implement
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserInfoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseView> Create(UserInfo user)
        {
            try
            {
                if(user == null) 
                {
                    return new ResponseView(MessageConstant.NO_DATA_REQUEST);
                }
                await _dbContext.UserInfos.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return new ResponseView(MessageConstant.CREATE_SUCCESS);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<int> GetInfoByUserId(int userId)
        {
            try
            {
                var info = await _dbContext.UserInfos.FirstOrDefaultAsync(s => s.UserId == userId);
                if(info == null)
                {
                    return -1;
                }
                return info.Id;
            }
            catch(Exception ex) 
            {
                Log.Error(ex.Message);
                return -1;
            }
        }

        public async Task<UserInfo?> GetUserInfoById(int userId)
        {
            try
            {
                var info = await _dbContext.UserInfos.FirstOrDefaultAsync(s => s.Id == userId);
                if (info == null)
                {
                    return null;
                }
                return info;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<UserInfo?> GetUserInfoByName(string userName)
        {
            try
            {
                var User = await _dbContext.Users.FirstOrDefaultAsync(s => s.UserName == userName);
                if (User == null)
                {
                    return null;
                }
                var info = await _dbContext.UserInfos.FirstOrDefaultAsync(s => s.UserId == User.Id);
                if (info == null)
                {
                    return null;
                }
                return info;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<ResponseView> Update(UserInfo user)
        {
            try
            {
                if (user == null)
                    return new(MessageConstant.NO_DATA_REQUEST);
                _dbContext.UserInfos.Update(user);
                await _dbContext.SaveChangesAsync();
                return new(MessageConstant.UPDATE_SUCCESS);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }
    }
}
