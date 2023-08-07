using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Comuna
    {
        public Comuna()
        {
            Administradors = new HashSet<Administrador>();
            Clientes = new HashSet<Cliente>();
            Profesionals = new HashSet<Profesional>();
        }

        public int IdComuna { get; set; }
        public string Nombre { get; set; } = null!;
        public int IdRegion { get; set; }

        public virtual Region IdRegionNavigation { get; set; } = null!;
        public virtual ICollection<Administrador> Administradors { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Profesional> Profesionals { get; set; }
    }
}
