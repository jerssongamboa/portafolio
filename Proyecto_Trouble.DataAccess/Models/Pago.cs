using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Pago
    {
        public decimal IdPago { get; set; }
        public string ClienteRut { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal IdEstado { get; set; }

        public virtual Cliente ClienteRutNavigation { get; set; } = null!;
        public virtual Estadopago IdEstadoNavigation { get; set; } = null!;
    }
}
