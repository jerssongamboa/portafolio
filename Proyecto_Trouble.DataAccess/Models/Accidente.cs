using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Accidente
    {
        public decimal IdAccidente { get; set; }
        public string ClienteRut { get; set; } = null!;
        public DateTime FechaAccidente { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual Cliente ClienteRutNavigation { get; set; } = null!;
    }
}
