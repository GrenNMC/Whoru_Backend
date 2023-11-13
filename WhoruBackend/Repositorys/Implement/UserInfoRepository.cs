using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;

namespace WhoruBackend.Repositorys.Implement
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserInfoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
