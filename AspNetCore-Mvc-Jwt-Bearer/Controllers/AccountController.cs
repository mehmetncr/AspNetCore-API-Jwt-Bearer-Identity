using AspNetCore_Mvc_Jwt_Bearer.Models;
using AspNetCore_Mvc_Jwt_Bearer.SessionExtensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AspNetCore_Mvc_Jwt_Bearer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var jsonData =JsonConvert.SerializeObject(model);
            var http = _httpClientFactory.CreateClient();
            var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var result = await http.PostAsync("https://localhost:7214/api/Auth/Login", content);
            if (result.IsSuccessStatusCode)
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("token", responseContent);
                return RedirectToAction("Index", "Home");
               
            }
       

            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var http = _httpClientFactory.CreateClient();
            var content = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var result = await http.PostAsync("https://localhost:7214/api/Auth/Register", content);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", result.Content.ToString());
                
            }
            return View(model);
        }
    }
}
