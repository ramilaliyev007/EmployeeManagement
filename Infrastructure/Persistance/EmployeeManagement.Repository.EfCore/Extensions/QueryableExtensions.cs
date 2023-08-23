using EmployeeManagement.Domain.Common.Dtos.Requests;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.EfCore.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> WhereIf<TEntity>(this IQueryable<TEntity> source,
                                                           bool condition,
                                                           Expression<Func<TEntity, bool>> expression)
            where TEntity : Entity
        {
            return WhereIf<TEntity, int>(source, condition, expression);
        }

        public static IQueryable<TEntity> WhereIf<TEntity, TId>(this IQueryable<TEntity> source,
                                                                bool condition,
                                                                Expression<Func<TEntity, bool>> expression)
            where TEntity : Entity<TId>
            where TId : struct
        {
            if (condition)
            {
                return source.Where(expression);
            }

            return source;
        }

        public static IQueryable<TEntity> PageBy<TEntity>(this IQueryable<TEntity> source, PageRequest request)
            where TEntity : Entity
        {
            return PageBy<TEntity, int>(source, request);
        }

        public static IQueryable<TEntity> PageBy<TEntity, TId>(this IQueryable<TEntity> source, PageRequest request)
            where TEntity : Entity<TId>
            where TId : struct
        {
            return source.Skip(request.Skip)
                         .Take(request.Take);
        }
    }
}
