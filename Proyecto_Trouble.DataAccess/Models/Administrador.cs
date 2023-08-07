using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Administrador
    {
        public string Rut { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int ComunaIdComuna { get; set; }
        public int RegionIdRegion { get; set; }
        public string Contrasena { get; set; } = null!;
        public decimal TipousuarioId { get; set; }
        public decimal EstadousuarioId { get; set; }

        public virtual Comuna ComunaIdComunaNavigation { get; set; } = null!;
        public virtual Estadousuario Estadousuario { get; set; } = null!;
        public virtual Region RegionIdRegionNavigation { get; set; } = null!;
        public virtual Tipousuario Tipousuario { get; set; } = null!;
    }
}
