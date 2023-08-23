using EmployeeManagement.Domain.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
