using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Estadopago
    {
        public Estadopago()
        {
            Pagos = new HashSet<Pago>();
        }

        public decimal Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
