using ISC_BT2.Models;
using ISC_BT2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ISC_BT2.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string?> AuthenticateUser(string username, string password)
        {
            var user = await _context.Users.Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);

            if (user == null) return null;

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var jwtKey = _config["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 16)
            {
                throw new ArgumentException("Jwt:Key must be at least 16 characters long.");
            }
            var key = Encoding.UTF8.GetBytes(jwtKey);
            

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                // new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "User")
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
