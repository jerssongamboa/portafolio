using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Accidentes = new HashSet<Accidente>();
            Actividades = new HashSet<Actividade>();
            Contratos = new HashSet<Contrato>();
            Pagos = new HashSet<Pago>();
            Reportes = new HashSet<Reporte>();
        }

        public string Rut { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string Rubro { get; set; } = null!;
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
        public virtual ICollection<Accidente> Accidentes { get; set; }
        public virtual ICollection<Actividade> Actividades { get; set; }
        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
