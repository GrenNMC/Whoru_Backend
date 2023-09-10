using WhoruBackend.ModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IlogRepository
    {
        public Task<ResponseLoginView> Login(LoginView view);
    }
}
