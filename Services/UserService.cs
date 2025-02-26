using ISC_BT2.Models;
using ISC_BT2.Data;
using Microsoft.EntityFrameworkCore;

namespace ISC_BT2.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
