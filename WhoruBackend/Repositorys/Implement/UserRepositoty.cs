using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.ModelViews.UserModelViews;
using WhoruBackend.Utilities.Constants;
using WhoruBackend.Utilities.SecurePassword;

namespace WhoruBackend.Repositorys.Implement
{
    public class UserRepositoty : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserRepositoty(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<ResponseView> Create(User user)
        {
            try
            {
                _dbcontext.Users.Add(user);
                await _dbcontext.SaveChangesAsync();
                return new ResponseView (MessageConstant.REGISTER_SUCCESS);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.REGISTER_FAILED);
            }
        }

        public async Task<List<UserDto>> GetAll()
        {
            var list = await _dbcontext.Users.ToListAsync();
            List<UserDto> users = new List<UserDto>();
            list.ForEach(user => {
                users.Add(new UserDto(user.Id,user.UserName,user.Email));
            });

            return users;
        }

        public async Task<User> GetUserByName(string name)
        {
                User user = await _dbcontext.Users.Where(s => s.UserName == name).FirstOrDefaultAsync();
                return user;
        }
    }
}
