// UserService.cs
using System.Linq;
using System.Threading.Tasks;
using DATABASEE.Context;
using DATABASEE.Models;
using Microsoft.EntityFrameworkCore;

namespace DATABASEE.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Users?> Authenticate(string username, int pin)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Pin == pin);
        }
    }
}
