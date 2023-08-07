using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.DTO
{
    public class ReporteDTO
    {
        public decimal IdReporte { get; set; }
        public string ClienteRut { get; set; } = null!;
        public DateTime FechaEmision { get; set; }
        public byte[] Archivo { get; set; } = null!;
    }
}
