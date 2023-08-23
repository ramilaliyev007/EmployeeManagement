using EmployeeManagement.Repository.Contracts;
using EmployeeManagement.Repository.EfCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.EfCore
{
    public static class Registrar
    {
        public static IServiceCollection AddEfCoreLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<EmployeeManagementDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("EmployeeManagement");

                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Transient);

            return services;
        }
    }
}
