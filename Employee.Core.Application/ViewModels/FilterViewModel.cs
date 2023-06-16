using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Application.ViewModels
{
    public class FilterViewModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Contratacion { get; set; }
    }
}
