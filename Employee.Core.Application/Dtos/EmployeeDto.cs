using Employee.Core.Domain.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Application.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile Fotografia { get; set; }
        public string? FotografiaUrl { get; set; } = default!;
        [Required(ErrorMessage = "Nombre es requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; } = default!;
        [Required(ErrorMessage = "Apellido es requerido")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; } = default!;
        [Required(ErrorMessage = "Fecha De Contratacion es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; } = default!;
        public string? Puesto { get; set; } = default!;
        public DateTime? FechaNacimiento { get; set; } = default!;

        public string? Direccion { get; set; } = default!;
        public string? Telefono { get; set; } = default!;
        public string? Correo { get; set; } = default!;
        public StatusEnum Estado { get; set; } = StatusEnum.Activo;
    }

    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string Correo { get; set; } = default!;
        public string Telefono { get; set; } = default!;

    }
}
