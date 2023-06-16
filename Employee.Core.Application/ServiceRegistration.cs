using Employee.Core.Application.Interfaces.Services;
using Employee.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Employee.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            service.AddTransient<IEmployeeService, EmployeeService>();
            service.AddTransient<IUploadFileService, UploadFileService>();

        }
    }
}
