using ISC_BT2.Models;
using ISC_BT2.Data;
using Microsoft.EntityFrameworkCore;

namespace ISC_BT2.Services
{
    public class AllowAccessService
    {
        private readonly ApplicationDbContext _context;

        public AllowAccessService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllowAccess>> GetAllAccesses()
        {
            return await _context.AllowAccesses.Include(a => a.Role).ToListAsync();
        }

        public async Task<bool> GrantAccess(AllowAccess access)
        {
            _context.AllowAccesses.Add(access);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RevokeAccess(int id)
        {
            var access = await _context.AllowAccesses.FindAsync(id);
            if (access == null) return false;

            _context.AllowAccesses.Remove(access);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
