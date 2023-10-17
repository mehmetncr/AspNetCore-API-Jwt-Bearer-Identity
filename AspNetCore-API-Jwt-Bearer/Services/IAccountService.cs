using AspNetCore_API_Jwt_Bearer.DTOs;
using System.Threading.Tasks;

namespace AspNetCore_API_Jwt_Bearer.Services
{
    public interface IAccountService
    {
        Task<string> Login(LoginDto model);
        Task<string> CreateUserAsync(RegisterDto model);
    }
}
