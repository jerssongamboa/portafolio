using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Region
    {
        public Region()
        {
            Administradors = new HashSet<Administrador>();
            Clientes = new HashSet<Cliente>();
            Comunas = new HashSet<Comuna>();
            Profesionals = new HashSet<Profesional>();
        }

        public int IdRegion { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Administrador> Administradors { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Comuna> Comunas { get; set; }
        public virtual ICollection<Profesional> Profesionals { get; set; }
    }
}
