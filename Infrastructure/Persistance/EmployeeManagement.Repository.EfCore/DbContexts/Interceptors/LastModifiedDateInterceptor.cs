using EmployeeManagement.Domain.Common.QueryFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EmployeeManagement.Repository.EfCore.DbContexts.Interceptors
{
    internal class LastModifiedDateInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                                                              InterceptionResult<int> result,
                                                                              CancellationToken cancellationToken = default)
        {
            var entries = eventData.Context
                                   .ChangeTracker
                                   .Entries<IHasLastModifiedDate>()
                                   .Where(x => x.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                entry.Entity!.LastModifiedDate = DateTime.Now;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
