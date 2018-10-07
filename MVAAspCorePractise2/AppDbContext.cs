using Microsoft.EntityFrameworkCore;

namespace MVAAspCorePractise2
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
    }
}