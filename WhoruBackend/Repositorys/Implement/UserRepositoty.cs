using WhoruBackend.Data;
using WhoruBackend.Models;
using WhoruBackend.Models.dto;

namespace WhoruBackend.Repositorys.Implement
{
    public class UserRepositoty : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserRepositoty(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public UserDto Create(UserDto userDto)
        {
            User user = new User { 
            UserName = userDto.UserName,
            Email = userDto.Email
            };
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
            return userDto;
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
