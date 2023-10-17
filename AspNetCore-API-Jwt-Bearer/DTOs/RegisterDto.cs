using System.ComponentModel.DataAnnotations;

namespace AspNetCore_API_Jwt_Bearer.DTOs
{
    public class RegisterDto
    {
        public int Id { get; set; }    
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
