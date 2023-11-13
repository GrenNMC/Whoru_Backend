using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.LogModelViews;

namespace WhoruBackend.Services
{
    public interface ILogService
    {
        public Task<ResponseLoginView> Login(LoginView view);
        public Task<ResponseView> SendCodeByMail();
        public Task<ResponseView> SendCodeBySMS();
        public Task<ResponseView> ActiveAccount(string code);
    }
}
