using System.Threading.Tasks;
using DATABASEE.Models;

namespace DATABASEE.Services
{
    public interface IUserService
    {
        Task<Users?> Authenticate(string username, int pin);
    }
}
