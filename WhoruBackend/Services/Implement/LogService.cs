using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.Repositorys;
using WhoruBackend.Utilities.Constants;
using WhoruBackend.Utilities.Emails;
using WhoruBackend.Utilities.SecurePassword;

namespace WhoruBackend.Services.Implement
{
    public class LogService : ILogService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepo;
        private readonly IUserService _userService;
        private readonly IUserInfoRepository _userInfoRepo;

        public LogService(IlogRepository logRepo, IUserRepository userRepo, IConfiguration configuration, IRoleRepository roleRepository, IUserService userService,IUserInfoRepository userInfo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepository;
            _configuration = configuration;
            _userService = userService;
            _userInfoRepo = userInfo;
        }


        public async Task<ResponseView> ActiveAccount(int id ,string code)
        {
            try
            {
                User? user = await _userRepo.GetUserById(id);
                if (user == null)
                {
                    return new ResponseView(MessageConstant.NOT_FOUND);
                }
                var activeCode = user.ActiveCode;
                if (activeCode == code)
                {
                    user.IsDisabled = false;
                    await _userRepo.UpdateUser(user);
                    var token = await CreateToken(user);
                    return new ResponseView(token);
                }
                //user.ActiveCode = string.Empty;
                //await _userRepo.UpdateUser(user);
                return new ResponseView(MessageConstant.VALIDATE_FAILED);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }
        public  async Task<ResponseView> SendCodeByMail(int idUser)
        {
            try
            {
                User? user = await _userRepo.GetUserById(idUser);
                if (user == null)
                {
                    return new ResponseView(MessageConstant.NOT_FOUND);
                }
                VerifyEmail email = new VerifyEmail();
                ValidateCodeProvider provider = new ValidateCodeProvider();
                if (user.Email != null && user.IsDisabled == true)
                {
                    string code = provider.ValidateCode(6);
                    email.SendMail(user.Email, code);
                    user.ActiveCode = code;
                    await _userRepo.UpdateUser(user);
                    return new ResponseView(user.Id.ToString());
                }
                return new ResponseView(MessageConstant.EMAIL_NOT_CONFIRMED);
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<ResponseView> SendCodeBySMS(int idUser)
        {
            try
            {
                User? user = await _userRepo.GetUserById(idUser);
                if (user == null)
                {
                    return new ResponseView(MessageConstant.NOT_FOUND);
                }
                return new ResponseView(MessageConstant.CODE_SENT);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return new ResponseView(MessageConstant.SYSTEM_ERROR);
            }
        }
        public async Task<ResponseLoginView> Login(LoginView view)
        {
            try
            {
                User? user = await _userRepo.GetUserByName(view.UserName);
                if (user == null)
                {
                    return new(MessageConstant.NOT_FOUND);
                }
                var checkPassword = new PasswordHasher().Verify(view.Password, user.Password);
                if (checkPassword == false)
                {
                    return new(MessageConstant.WRONG_PASSWORD);
                }
                var info = await _userInfoRepo.GetInfoByUserId(user.Id);
                if (user.IsDisabled == true)
                {
                    return new(user.Id, info, MessageConstant.LOGIN_SUCCESS, user.UserName, null, user.IsDisabled);
                }

                var token = await CreateToken(user);
                return new(user.Id, info, MessageConstant.LOGIN_SUCCESS, user.UserName, token, user.IsDisabled);

            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }

        public async Task<ResponseView> ChangePassword(string pass, string prePass)
        {
            try
            {
                int id = await _userService.GetIdByToken();
                User? user = await _userRepo.GetUserById(id);
                if (user == null)
                {
                    return new ResponseView(MessageConstant.NOT_FOUND);
                }
                var checkPassword = new PasswordHasher().Verify(prePass, user.Password);
                if(checkPassword == true)
                {
                    user.Password = new PasswordHasher().HashToString(pass);
                    await _userRepo.UpdateUser(user);
                    return new ResponseView(MessageConstant.CHANGE_PASSWORD_SUCCESS);
                }
                else
                {
                    return new ResponseView(MessageConstant.OLD_PASS_INCORRECT);
                }
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }
        private async Task<string> CreateToken(User user)
        {
            //mã hóa key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //ký vào key đã mã hóa
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            string role = await _roleRepo.GetRoleName(user.RoleId);
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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
            return UserToken;
        }
        public async Task<ResponseView> VerifyPass(string mail, string code)
        {
            try
            {
                User? user = await _userRepo.GetUserByMail(mail);
                if (user == null)
                {
                    return new(MessageConstant.NOT_FOUND);
                }
                if (user.ActiveCode != code) 
                {
                    return new(MessageConstant.VALIDATE_FAILED);
                }

                VerifyEmail email = new VerifyEmail();
                ValidateCodeProvider provider = new ValidateCodeProvider();
                string newPass = provider.ValidateCode(8);
                user.Password = new PasswordHasher().HashToString(newPass); ;
                await _userRepo.UpdateUser(user);
                email.ResetPassword(mail, newPass);
                return new ResponseView(user.Id.ToString());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }
        public async Task<ResponseView> ResetPassword(string mail)
        {
            try
            {
                User? user = await _userRepo.GetUserByMail(mail);
                if(user == null)
                {
                    return new(MessageConstant.NOT_FOUND);
                }

                VerifyEmail email = new VerifyEmail();
                ValidateCodeProvider provider = new ValidateCodeProvider();
                string newCode = provider.ValidateCode(8);
                user.ActiveCode = newCode;
                await _userRepo.UpdateUser(user);
                email.SendVerifyCode(mail, newCode);
                return new ResponseView(user.Id.ToString());
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return new(MessageConstant.SYSTEM_ERROR);
            }
        }
    }
}
