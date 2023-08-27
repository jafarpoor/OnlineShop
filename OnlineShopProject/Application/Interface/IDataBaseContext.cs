using Application.ViewModel;
using Domain.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Application.Interface
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
