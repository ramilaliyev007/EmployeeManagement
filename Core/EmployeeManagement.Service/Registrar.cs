using EmployeeManagement.Service.Contracts.Services;
using EmployeeManagement.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Service
{
    public static class Registrar
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IDepartmentService, DepartmentService>();

            return services;
        }
    }
}
