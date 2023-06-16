using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Application.Interfaces.Services
{
    public interface IGenericService<ViewModel, T>
        where ViewModel : class
        where T : class
    {
        Task<List<ViewModel>> GetAllAsync();
        Task<ViewModel> GetByIdAsync(int id);
        Task<ViewModel> AddAsync(ViewModel vm);
        Task UpdateAsync(ViewModel vm, int id);

        Task DeleteAsync(int id);
    }
}
