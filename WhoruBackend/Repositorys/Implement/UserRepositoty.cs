using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.Models.dto;
using WhoruBackend.ModelViews;
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

        public ResponseView Create(RegisterView user)
        {
            User account = new User {
            UserName = user.UserName,
            Email = user.Email,
            Password = new PasswordHasher().HashToString(user.Password),
            RoleId = 2,
            Phone = user.Phone,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            isDisabled = true,
            };
            try
            {
                _dbcontext.Users.Add(account);
                _dbcontext.SaveChanges();
                return new ResponseView ("Đăng ký thành công");
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView("Đăng ký thất bại");
            }
        }

        public List<UserDto> GetAll()
        {
            var list = _dbcontext.Users.ToList();
            List<UserDto> users = new List<UserDto>();
            list.ForEach(user => {
                users.Add(new UserDto(user.Id,user.UserName,user.Email));
            });

            return users;
        }
    }
}
