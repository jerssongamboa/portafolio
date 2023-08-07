using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.DTO
{
    public class ComunaDTO
    {
        public int IdComuna { get; set; }
        public string Nombre { get; set; } = null!;
        public int IdRegion { get; set; }
    }
}
