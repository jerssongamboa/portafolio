using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class Profesionalactividad
    {
        public Profesionalactividad()
        {
            Profesionals = new HashSet<Profesional>();
        }

        public decimal Id { get; set; }
        public string Actividad { get; set; } = null!;

        public virtual ICollection<Profesional> Profesionals { get; set; }
    }
}
