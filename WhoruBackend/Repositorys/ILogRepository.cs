using Microsoft.AspNetCore.Mvc;
using WhoruBackend.ModelViews.LogModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IlogRepository
    {
        public Task<ResponseLoginView> Login(LoginView view);
    }
}
