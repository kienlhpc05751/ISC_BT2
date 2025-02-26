using ISC_BT2.Models;
using ISC_BT2.Data;
using Microsoft.EntityFrameworkCore;

namespace ISC_BT2.Services
{
    public class RoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<bool> CreateRole(Role role)
        {
            _context.Roles.Add(role);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            _context.Roles.Remove(role);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
