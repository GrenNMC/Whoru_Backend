using WhoruBackend.Models;
using WhoruBackend.ModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IFeedRepository
    {
        public Task<ResponseView> Create(Feed feed);
    }
}
