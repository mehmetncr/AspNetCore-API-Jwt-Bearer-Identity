using AspNetCore_API_Jwt_Bearer.DTOs;
using AspNetCore_API_Jwt_Bearer.Entities;
using AspNetCore_API_Jwt_Bearer.Repositories;
using AutoMapper;

namespace AspNetCore_API_Jwt_Bearer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public EmployeeDto Get(int id)
        {
            return _mapper.Map<EmployeeDto>(_employeeRepository.GetById(id));
        }

        public List<EmployeeDto> GetAll()
        {
           return  _mapper.Map<List<EmployeeDto>>( _employeeRepository.GetAll());
        }
    }
}
