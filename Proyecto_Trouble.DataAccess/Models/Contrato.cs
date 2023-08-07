using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Contrato
    {
        public Contrato()
        {
            Actividades = new HashSet<Actividade>();
        }

        public string IdContrato { get; set; } = null!;
        public string ClienteRut { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }

        public virtual Cliente ClienteRutNavigation { get; set; } = null!;
        public virtual ICollection<Actividade> Actividades { get; set; }
    }
}
