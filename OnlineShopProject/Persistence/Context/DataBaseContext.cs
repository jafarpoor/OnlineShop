using Domain.Entity;
using Domain.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Color> Colors { get; set; }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                         .Entries()
                         .Where(e => e.Entity is BaseEntity && (
                                 e.State == EntityState.Added
                                 || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
