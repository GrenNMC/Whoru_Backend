using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews.LogModelViews;
using WhoruBackend.Repositorys;

namespace WhoruBackend.Services.Implement
{
    public class LogService : ILogService
    {
        private readonly IlogRepository _LogRepo;

        public LogService(IlogRepository logRepo)
        {
            _LogRepo = logRepo;
        }

        public async Task<ResponseLoginView> Login(LoginView view)
        {
            return await _LogRepo.Login(view);
        }
    }
}
