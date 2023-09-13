using Microsoft.EntityFrameworkCore;
using WhoruBackend.Data;
using WhoruBackend.ModelViews;
using WhoruBackend.Utilities.Constants;
using WhoruBackend.Utilities.SecurePassword;

namespace WhoruBackend.Repositorys.Implement
{
    public class LogRepository : IlogRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public LogRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<ResponseLoginView> Login(LoginView view)
        {
            try
            {
                var user = await _DbContext.Users.Where(s => s.UserName == view.UserName).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new(MessageConstant.NOT_FOUND);
                }
                 var checkPassword = new PasswordHasher().Verify(view.Password, user.Password);
                 if (checkPassword == false)
                 {
                    return new(MessageConstant.WRONG_PASSWORD);
                 }       
                return new (user.Id, MessageConstant.LOGIN_SUCCESS, user.UserName);
            }
            catch (Exception e)
            { 
                //Console.WriteLine(e);
                return new (MessageConstant.SYSTEM_ERROR);
            }
        }
    }
}
