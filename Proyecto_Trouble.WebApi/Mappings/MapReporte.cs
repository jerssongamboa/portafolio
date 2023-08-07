using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{

    public static partial class Mapper
    {
        public static ReporteDTO ToDTO(this Reporte model)  // Convierte de ModelContext a DTO
        {
            return new ReporteDTO()
            {
                IdReporte = model.IdReporte,
                ClienteRut = model.ClienteRut,
                FechaEmision = model.FechaEmision,
                Archivo = model.Archivo

            };
        }
    }

    public static partial class Mapper
    {
        public static Reporte ToDatabase(this ReporteDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Reporte()
            {
                IdReporte = dto.IdReporte,
                ClienteRut = dto.ClienteRut,
                FechaEmision = dto.FechaEmision,
                Archivo = dto.Archivo

            };
        }
    }
}
