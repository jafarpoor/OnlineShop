using Domain.Entity;
using Domain.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace Persistence.Context;

public interface IDataBaseContext : IDisposable
{
    DbSet<User> Users { get; set; }
    DbSet<ProductType> ProductTypes { get; set; }
     DbSet<ProductItem> ProductItems { get; set; }
     DbSet<Image> Images { get; set; }
     DbSet<Feature> Features { get; set; }
     DbSet<Color> Colors { get; set; }

    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class;
}
