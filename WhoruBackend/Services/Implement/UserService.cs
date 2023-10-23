using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.ModelViews.UserModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;
using WhoruBackend.Utilities.SecurePassword;

namespace WhoruBackend.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseView> Create(RegisterView user)
        {
            var register = await _userRepository.GetUserByName(user.UserName);
            if (register == null)
            {
                User account = new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = new PasswordHasher().HashToString(user.Password),
                    RoleId = 2,
                    Phone = user.Phone,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    isDisabled = true,
                };
                return await _userRepository.Create(account);
            }
            else return new ResponseView(MessageConstant.DUPLICATE_USERNAME);
        }

        public async Task<List<UserDto>> GetAll()
        {
            return await _userRepository.GetAll();
        }
        public async Task<string> GetNameByToken()
        {
            var id = string.Empty;
            if(_httpContextAccessor.HttpContext is not null)
            {
                id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return id;
        }

    }
}
