using Azure;
using System.Collections.Generic;
using WhoruBackend.Models;
using WhoruBackend.ModelViews;
using WhoruBackend.ModelViews.FollowModelViews;

namespace WhoruBackend.Repositorys
{
    public interface IFollowRepository
    {
        public Task<ResponseView> FollowUser(int idFollower, int idUser);
        public Task<ResponseView> UnFollowUser(int idFollower, int idUser);

        public Task<List<FollowerModelView>?> GetAllFollower(int idUser);
        public Task<List<FollowerModelView>?> GetAllFollowing(int idUser);
    }
}
