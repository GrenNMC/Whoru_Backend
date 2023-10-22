using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WhoruBackend.Models;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;
using WhoruBackend.Utilities.SecurePassword;

namespace WhoruBackend.Services.Implement
{
    public class LogService : ILogService
    {
        private readonly IUserRepository _UserRepo;
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;

        public LogService(IlogRepository logRepo, IUserRepository userRepo, IConfiguration configuration, IRoleRepository roleRepository)
        {
            _UserRepo = userRepo;
            _roleRepository = roleRepository;
            _configuration = configuration;
        }

        public async Task<ResponseLoginView> Login(LoginView view)
        {
            try
            {
                User user = await _UserRepo.GetUserByName(view.UserName);
                if (user == null)
                {
                    return new(MessageConstant.NOT_FOUND);
                }
                var checkPassword = new PasswordHasher().Verify(view.Password, user.Password);
                if (checkPassword == false)
                {
                    return new(MessageConstant.WRONG_PASSWORD);
                }
                //mã hóa key
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                //ký vào key đã mã hóa
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                string role = await _roleRepository.GetRoleName(user.RoleId);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                };
                //tạo token
                var token = new JwtSecurityToken
                    (
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: credentials,
                        claims: claims
                    );
                //sinh ra chuỗi token với các thông số ở trên
                var UserToken = new JwtSecurityTokenHandler().WriteToken(token);
                //Có thể tạo claims chứa thông tin người dùng (nếu cần)
                return new(user.Id, MessageConstant.LOGIN_SUCCESS, user.UserName, UserToken);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }
    }
}
