namespace WhoruBackend.Repositorys
{
    public interface IUserInfoRepository
    {
        public Task<int> GetInfoByUserId(int userId);
    }
}
