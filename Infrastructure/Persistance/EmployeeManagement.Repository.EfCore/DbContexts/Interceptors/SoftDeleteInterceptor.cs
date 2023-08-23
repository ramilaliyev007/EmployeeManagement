using EmployeeManagement.Domain.Common.QueryFilters;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.EfCore.DbContexts.Interceptors
{
    internal class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                                                              InterceptionResult<int> result,
                                                                              CancellationToken cancellationToken = default)
        {
            var entries = eventData.Context!
                                   .ChangeTracker
                                   .Entries<IHasSoftDelete>()
                                   .Where(x => x.State == EntityState.Deleted);

            foreach (var entry in entries)
            {
                if (entry.Entity is IHasDeletedDate hasDeletedDateEntity)
                {
                    hasDeletedDateEntity.DeletedDate = DateTime.Now;
                }

                entry.Entity!.IsDeleted = true;

                entry.State = EntityState.Modified;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
