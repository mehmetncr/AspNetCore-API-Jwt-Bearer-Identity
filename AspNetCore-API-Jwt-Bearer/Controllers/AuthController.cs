using AspNetCore_API_Jwt_Bearer.DTOs;
using AspNetCore_API_Jwt_Bearer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_API_Jwt_Bearer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {       
            _accountService = accountService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {

             var token = await _accountService.Login(model);



            return Ok(token);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {

           string msg = await _accountService.CreateUserAsync(model);
            if (msg =="Ok")
            {
                return Created("", "Kayıt Başarılı");
            }
            else
            {
                return BadRequest("Kayıt başarısız. Lütfen geçerli bilgileri sağlayın.");

            }


        }

    }
}


//[HttpPost]
//public IActionResult Login()
//{
//    return Created("", _authService.GenereteToken());
//}