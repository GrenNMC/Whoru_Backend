using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Models;

namespace WhoruBackend.Repositorys.Implement
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<string> GetRoleName(int Id)
        {
                Role role = await _DbContext.Roles.Where(s => s.Id == Id).FirstOrDefaultAsync();
                return role.RoleName;
        }
    }
}
