using AspNetCore_API_Jwt_Bearer.Entities;
using AspNetCore_API_Jwt_Bearer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_API_Jwt_Bearer.Context
{
    public class BearerDbContext : IdentityDbContext<AppUser, AppRole,int>
    {
        public BearerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
