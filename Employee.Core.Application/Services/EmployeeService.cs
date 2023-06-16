using AutoMapper;
using Employee.Core.Application.Dtos;
using Employee.Core.Application.Interfaces.Repositories;
using Employee.Core.Application.Interfaces.Services;
using Employee.Core.Application.ViewModels;
using Employee.Core.Domain.Common.Enums;
using Employee.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Application.Services
{
    public class EmployeeService : GenericService<EmployeeDto, Employees>, IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public override async Task<List<EmployeeDto>> GetAllAsync()
        {
            var lista = await _repo.GetAllAsync();
            lista = lista.Where(e => e.Estado == StatusEnum.Activo).ToList();
            return _mapper.Map<List<EmployeeDto>>(lista);
        }


        public async Task EmployeeTermination(int id)
        {
            Employees employee = await _repo.GetByIdAsync(id);
            employee.Estado = Domain.Common.Enums.StatusEnum.Inactivo;
            await _repo.UpdateAsync(employee, employee.Id);
        }

        public async Task<List<EmployeeDto>> GetAllWithFilters(FilterViewModel filters)
        {
            var list = await _repo.GetAllAsync();

            if (string.IsNullOrWhiteSpace(filters.Nombre))
            {
                if (!string.IsNullOrEmpty(filters.Apellido))
                {

                    list = list.Where(c => c.Nombre.Trim().ToLower() == filters.Nombre.Trim().ToLower()
                        && c.Apellido.Trim().ToLower() == filters.Apellido.Trim().ToLower()).ToList();

                    return _mapper.Map<List<EmployeeDto>>(list);
                }
                list = list.Where(c => c.Nombre.Trim().ToLower() == filters.Nombre.Trim().ToLower()).ToList();

                return _mapper.Map<List<EmployeeDto>>(list);

            }

            return _mapper.Map<List<EmployeeDto>>(list);
        }

        public async Task ParcialUpdateAsync(UpdateEmployeeDto vm)
        {
            Employees employee = await _repo.GetByIdAsync(vm.Id);
            employee.Correo = vm.Correo;
            employee.Telefono = vm.Telefono;
            await _repo.UpdateAsync(employee, employee.Id);
        }
    }
}
