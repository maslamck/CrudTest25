using CrudTest25.Api.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CrudTest25.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
