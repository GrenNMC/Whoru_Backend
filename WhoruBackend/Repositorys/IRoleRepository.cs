namespace WhoruBackend.Repositorys
{
    public interface IRoleRepository
    {
        public Task<string> GetRoleName(int Id);
    }
}
