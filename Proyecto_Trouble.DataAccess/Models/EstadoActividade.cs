using System;
using System.Collections.Generic;

namespace Proyecto_Trouble.DataAccess.Models
{
    public partial class EstadoActividade
    {
        public int IdEstado { get; set; }
        public string Estado { get; set; } = null!;
    }
}
