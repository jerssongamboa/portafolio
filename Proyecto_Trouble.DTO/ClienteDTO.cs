﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.DTO
{
    public class ClienteDTO
    {
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

    }
}
