using E_CommerceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApi.Persistence.Contexts
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Product> Products { get; set; }
        public DbSet <Order> Orders { get; set; }
        public DbSet <Customer> Customers { get; set; }
    }
}
