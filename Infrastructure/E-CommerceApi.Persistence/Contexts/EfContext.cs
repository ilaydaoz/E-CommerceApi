using E_CommerceApi.Domain.Entities;
using E_CommerceApi.Shared.Entities;
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
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da
               //yeni eklenen verinin yakalanmasını sağlayan propertydir.
              //Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
