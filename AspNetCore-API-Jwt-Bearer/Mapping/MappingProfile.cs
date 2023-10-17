using AspNetCore_API_Jwt_Bearer.DTOs;
using AspNetCore_API_Jwt_Bearer.Entities;
using AutoMapper;

namespace AspNetCore_API_Jwt_Bearer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
