﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WhoruBackend.Data;
using WhoruBackend.ModelViews;
using WhoruBackend.Utilities.Constants;
using WhoruBackend.Utilities.SecurePassword;

namespace WhoruBackend.Repositorys.Implement
{
    public class LogRepository : IlogRepository
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IConfiguration _configuration;
        public LogRepository(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _DbContext = dbContext;
            _configuration = configuration;
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
                // Get role
                var role = from n in _DbContext.Roles
                           where n.Id == user.RoleId
                           select n.RoleName;
                
                //mã hóa key
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                //ký vào key đã mã hóa
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, role.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                };
                //tạo token
                //var token = new JwtSecurityToken
                //    (
                //        issuer: _configuration["Jwt:Issuer"],
                //        audience: _configuration["Jwt:Audience"],
                //        expires: DateTime.Now.AddHours(1),
                //        signingCredentials: signingCredential,
                //        claims: claim
                //    );

                var token = new JwtSecurityToken
                (
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials
                );
                //sinh ra chuỗi token với các thông số ở trên
                var UserToken = new JwtSecurityTokenHandler().WriteToken(token);
                //Có thể tạo claims chứa thông tin người dùng (nếu cần)
                return new (user.Id, MessageConstant.LOGIN_SUCCESS, user.UserName, UserToken);
            }
            catch (Exception e)
            { 
                Console.WriteLine(e);
                return new (MessageConstant.SYSTEM_ERROR);
            }
        }
    }
}
