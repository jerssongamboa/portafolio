using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.DTO
{
    public class ContratoDTO
    {
        public string IdContrato { get; set; } = null!;
        public string ClienteRut { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
    }
}
