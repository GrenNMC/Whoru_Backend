using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;

namespace WhoruBackend.Repositorys.Implement
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetRoleName(int Id)
        {
            try
            {
                Role? role = await _dbContext.Roles.Where(s => s.Id == Id).FirstOrDefaultAsync();
                if (role == null || role.RoleName == null)
                {
                    return string.Empty;
                }
                return role.RoleName;
            }
            catch (Exception ex) 
            {
                Log.Error(ex.Message);
                return string.Empty;
            }
        }
    }
}
