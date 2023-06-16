using AutoMapper;
using Employee.Core.Application.Dtos;
using Employee.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region 'mappings'

            #region 'Employee'

            CreateMap<Employees, EmployeeDto>()
                    .ForMember(c => c.Fotografia, opt => opt.Ignore())
                    .ReverseMap();

            #endregion

            #endregion
        }
    }
}
