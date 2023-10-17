using AspNetCore_Mvc_Jwt_Bearer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AspNetCore_Mvc_Jwt_Bearer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //Account controller login ekranından alınacak username ve password bilgler /api/Auth metoduna post edilecek
            //api gelen user bilgilerini oğruladıktan sonra ürettiği token bilgisini buraya gönderecek bu token bilgisi her istek öncesi aşağıdaki gibi  rewuest heaer içine apiden listeler çekilebilecek
            var token = HttpContext.Session.GetString("token");
            var http = _httpClientFactory.CreateClient();
            //istekte bulunurken token  header içinde gönderir
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme,token);
            var respons = await http.GetAsync("https://localhost:7214/api/Employees");  //API adresi ve get isteği 
            var code = respons.StatusCode;
            if (respons.StatusCode == System.Net.HttpStatusCode.OK)  //gelen sonuç Ok ise  kodu ise
            {
                var jsonData = await respons.Content.ReadAsStringAsync();  //gelen datanın içindeki veriler çıkarılır
                var data = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(jsonData);  //gelen Json Tipindeki data view modele deserilize edilir
                return View(data);
            }
            return View();
        }
        public async Task<IActionResult> GetEmployee(int id)
        {
            //Account controller login ekranından alınacak username ve password bilgler /api/Auth metoduna post edilecek
            //api gelen user bilgilerini oğruladıktan sonra ürettiği token bilgisini buraya gönderecek bu token bilgisi her istek öncesi aşağıdaki gibi  rewuest heaer içine apiden listeler çekilebilecek
            var token = HttpContext.Session.GetString("token");
            var http = _httpClientFactory.CreateClient();
            //istekte bulunurken token  header içinde gönderir
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);
            var respons = await http.GetAsync("https://localhost:7214/api/Employees/"+id);  //API adresi ve get isteği 
            var code = respons.StatusCode;
            if (respons.StatusCode == System.Net.HttpStatusCode.OK)  //gelen sonuç Ok ise  kodu ise
            {
                var jsonData = await respons.Content.ReadAsStringAsync();  //gelen datanın içindeki veriler çıkarılır
                var data = JsonConvert.DeserializeObject<EmployeeViewModel>(jsonData);  //gelen Json Tipindeki data view modele deserilize edilir
                return View(data);
            }
            return View();
        }
    }
}
