namespace AspNetCore_API_Jwt_Bearer.Services
{
    public interface IAuthService
    {
        string GenereteToken(IList<string> roles);
    }
}
