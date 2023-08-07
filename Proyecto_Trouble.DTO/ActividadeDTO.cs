using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.DTO
{
    public class ActividadeDTO
    {
        public decimal IdActividad { get; set; }
        public string ClienteRut { get; set; } = null!;
        public DateTime FechaPlanificada { get; set; }
        public DateTime FechaTerminoEstipulado { get; set; }
        public DateTime? FechaTerminoReal { get; set; }
        public string ProfesionalAsignado { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string TipoActividad { get; set; } = null!;
        public string ContratoId { get; set; } = null!;
        public string Extra { get; set; } = null!;
    }
}
