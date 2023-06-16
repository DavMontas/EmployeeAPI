using Employee.Core.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Domain.Entities
{
    public class Employees
    {
        public int Id { get; set; }
        public string? FotografiaUrl { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Apellido { get; set; } = default!;
        public DateTime FechaContratacion { get; set; } = default!;
        public string? Puesto { get; set; } = default!;
        public DateTime? FechaNacimiento { get; set; } = default!;
        public string? Direccion { get; set; } = default!;
        public string? Telefono { get; set; } = default!;
        public string? Correo { get; set; } = default!;
        public StatusEnum Estado { get; set; } = StatusEnum.Activo;
    }
}
