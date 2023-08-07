using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Actividade
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

        public virtual Cliente ClienteRutNavigation { get; set; } = null!;
        public virtual Contrato Contrato { get; set; } = null!;
        public virtual Profesional ProfesionalAsignadoNavigation { get; set; } = null!;
    }
}
