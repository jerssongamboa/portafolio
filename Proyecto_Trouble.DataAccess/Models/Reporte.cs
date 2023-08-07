using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Reporte
    {
        public decimal IdReporte { get; set; }
        public string ClienteRut { get; set; } = null!;
        public DateTime FechaEmision { get; set; }
        public byte[] Archivo { get; set; } = null!;

        public virtual Cliente ClienteRutNavigation { get; set; } = null!;
    }
}
