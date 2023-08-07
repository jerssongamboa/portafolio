using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.DTO
{
    public class AccidenteDTO
    {
        public decimal IdAccidente { get; set; }
        public string ClienteRut { get; set; } = null!;
        public DateTime FechaAccidente { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
