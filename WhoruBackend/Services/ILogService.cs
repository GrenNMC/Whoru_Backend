using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;

namespace WhoruBackend.Services
{
    public interface ILogService
    {
        public Task<ResponseLoginView> Login(LoginView view);
        public Task<ResponseView> SendCodeByMail(int id);
        public Task<ResponseView> SendCodeBySMS(int id);
        public Task<ResponseView> ActiveAccount(int id, string code);
        public Task<ResponseView> ChangePassword(string pass);
        public Task<ResponseView> ResetPassword(string mail);
    }
}
