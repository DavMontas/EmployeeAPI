using Employee.Core.Application.Dtos;
using Employee.Core.Application.ViewModels;
using Employee.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Core.Application.Interfaces.Services
{
    public interface IEmployeeService : IGenericService<EmployeeDto, Employees>
    {
        Task ParcialUpdateAsync(UpdateEmployeeDto vm);
        Task EmployeeTermination(int id);
        Task<List<EmployeeDto>> GetAllWithFilters(FilterViewModel filters);
        Task<List<EmployeeDto>> GetAllAsync();


    }
}
