using DDD.Infrastucture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastucture.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddEmployeeManagementServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeAppService, EmployeeAppService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            return services;
        }
    }
}
