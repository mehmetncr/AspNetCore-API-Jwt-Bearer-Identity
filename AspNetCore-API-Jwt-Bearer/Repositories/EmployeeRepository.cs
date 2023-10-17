using AspNetCore_API_Jwt_Bearer.Context;
using AspNetCore_API_Jwt_Bearer.Entities;

namespace AspNetCore_API_Jwt_Bearer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BearerDbContext _context;

        public EmployeeRepository(BearerDbContext context)
        {
            _context = context;
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(x=>x.Id==id)!;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public Employee Create(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee employee)
        {
            throw new NotImplementedException();
        }

      

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
