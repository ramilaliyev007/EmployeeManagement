using EmployeeManagement.Domain.Common.QueryFilters;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.EfCore.DbContexts.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeeManagement.Repository.EfCore.DbContexts
{
    public class EmployeeManagementDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; init; }

        public DbSet<Department> Departments { get; init; }

        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new LastModifiedDateInterceptor())
                          .AddInterceptors(new SoftDeleteInterceptor());

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
