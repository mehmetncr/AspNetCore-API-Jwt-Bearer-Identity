using AspNetCore_API_Jwt_Bearer.DTOs;
using AspNetCore_API_Jwt_Bearer.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore_API_Jwt_Bearer.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthService authService)
        {
            _userManager = userManager;

            _signInManager = signInManager;
            _authService = authService;
        }

        public async Task<string> Login(LoginDto model)
        {
            string message = string.Empty;
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)  //kullanıcı bulunamazsa
            {
                message = "user not found";
                return message;
            }
            var identityresult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);   //kullanıcı bulunursa şifre kontrolu yapılır, beni hatırla demişse, kilitlenme açık
            if (identityresult.Succeeded)  //giriş başarılı ise
            {
                try
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    return _authService.GenereteToken(roles);
                }
                catch (Exception)
                {

                    throw;
                }
                  
            }       
            else
            {
                message = "wrong user";
            }
            return message;
            
        }
        public async Task<string> CreateUserAsync(RegisterDto model)
        {
            string message = string.Empty;
            var user = new AppUser() //yeni bir kullanıcı gelen model verileri ile oluşturulur
            {           
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName             

            };
            var identityresult = await _userManager.CreateAsync(user, model.Password);
            if (identityresult.Succeeded)    //başarılı ise
            {

                message = "Ok";

            }
            else
            {
                foreach (var error in identityresult.Errors)  //değilse
                {
                    message = error.Description;
                }
            }
            return message;
        }
    }
}
