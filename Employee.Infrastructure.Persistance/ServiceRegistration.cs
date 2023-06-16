using Employee.Core.Application.Interfaces.Repositories;
using Employee.Infrastructure.Persistance.Contexts;
using Employee.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Employee.Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            #region repositories
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IEmployeeRepository, EmployeeRepository>();
            #endregion
        }
    }
}
