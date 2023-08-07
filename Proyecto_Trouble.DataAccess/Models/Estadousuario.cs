using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Estadousuario
    {
        public Estadousuario()
        {
            Administradors = new HashSet<Administrador>();
            Clientes = new HashSet<Cliente>();
            Profesionals = new HashSet<Profesional>();
        }

        public decimal Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Administrador> Administradors { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Profesional> Profesionals { get; set; }
    }
}
