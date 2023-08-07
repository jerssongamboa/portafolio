using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.DTO
{
    public class PagoDTO
    {
        public decimal IdPago { get; set; }
        public string ClienteRut { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal IdEstado { get; set; }
    }
}
