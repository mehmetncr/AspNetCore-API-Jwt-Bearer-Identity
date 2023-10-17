using AspNetCore_API_Jwt_Bearer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_API_Jwt_Bearer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
      
        [HttpGet]
        [Authorize( Roles = "Admin")]
        public IActionResult GetEmpoyees()
        {
            return Ok(_employeeService.GetAll());
        }
        [HttpGet("{id}")]

        [Authorize]

        public IActionResult GetEmpoyee(int id)
        {
            return Ok(_employeeService.Get(id));
        }
    }
}
