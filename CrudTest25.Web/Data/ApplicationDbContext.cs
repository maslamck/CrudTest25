using CrudTest25.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudTest25.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }
    }
}
