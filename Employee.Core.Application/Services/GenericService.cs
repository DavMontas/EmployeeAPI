using AutoMapper;
using Employee.Core.Application.Interfaces.Repositories;
using Employee.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Application.Services
{
    public class GenericService<ViewModel, T> : IGenericService<ViewModel, T>
         where ViewModel : class
         where T : class
    {
        private readonly IGenericRepository<T> _repo;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public virtual async Task<ViewModel> AddAsync(ViewModel vm)
        {
            T entity = _mapper.Map<T>(vm);
            entity = await _repo.AddAsync(entity);
            ViewModel viewModel = _mapper.Map<ViewModel>(entity);
            return viewModel;
        }

        public virtual async Task DeleteAsync(int id)
        {
            T entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }

        public virtual async Task<List<ViewModel>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<List<ViewModel>>(list);
        }

        public virtual async Task<ViewModel> GetByIdAsync(int id)
        {
            T entity = await _repo.GetByIdAsync(id);
            ViewModel vm = _mapper.Map<ViewModel>(entity);
            return vm;
        }

        public virtual async Task UpdateAsync(ViewModel vm, int id)
        {
            T entity = _mapper.Map<T>(vm);
            await _repo.UpdateAsync(entity, id);
        }
    }
}
