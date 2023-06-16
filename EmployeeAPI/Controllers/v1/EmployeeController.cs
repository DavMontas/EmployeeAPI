using Employee.Core.Application.Dtos;
using Employee.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace EmployeeAPI.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _svc;
        public EmployeeController(IEmployeeService svc)
        {
            _svc = svc;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateEmployeeDto dto, CancellationToken cancellationToken)
        {
            await _svc.ParcialUpdateAsync(dto);

            return NoContent();
        }
    }
}
