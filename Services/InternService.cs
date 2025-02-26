using ISC_BT2.Models;
using ISC_BT2.Data;
using Microsoft.EntityFrameworkCore;

namespace ISC_BT2.Services
{
    public class InternService
    {
        private readonly ApplicationDbContext _context;

        public InternService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<object>> GetInternsForUser(int roleId)
        {
            var allowedColumns = await _context.AllowAccesses
                .Where(a => a.RoleId == roleId && a.TableName == "Intern")
                .Select(a => a.AccessProperties)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(allowedColumns))
                return new List<object>();

            var columnList = allowedColumns.Split(',');

            return await _context.Interns
                .Select(intern => new
                {
                    InternName = columnList.Contains("InternName") ? intern.InternName : null,
                    InternMail = columnList.Contains("InternMail") ? intern.InternMail : null,
                    Major = columnList.Contains("Major") ? intern.Major : null
                })
                .ToListAsync<object>();
        }
    }
}
