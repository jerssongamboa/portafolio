using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
    public static partial class Mapper
    {
        public static ActividadeDTO ToDTO(this Actividade model)  // Convierte de ModelContext a DTO
        {
            return new ActividadeDTO()
            {
                IdActividad = model.IdActividad,
                ClienteRut = model.ClienteRut,
                FechaPlanificada = model.FechaPlanificada,
                FechaTerminoEstipulado = model.FechaTerminoEstipulado,
                FechaTerminoReal = model.FechaTerminoReal,
                ProfesionalAsignado = model.ProfesionalAsignado,
                Descripcion = model.Descripcion,
                TipoActividad = model.TipoActividad,
                ContratoId = model.ContratoId,
                Extra = model.Extra

            };
        }
    }

    public static partial class Mapper
    {
        public static Actividade ToDatabase(this ActividadeDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Actividade()
            {
                IdActividad = dto.IdActividad,
                ClienteRut = dto.ClienteRut,
                FechaPlanificada = dto.FechaPlanificada,
                FechaTerminoEstipulado = dto.FechaTerminoEstipulado,
                FechaTerminoReal = dto.FechaTerminoReal,
                ProfesionalAsignado = dto.ProfesionalAsignado,
                Descripcion = dto.Descripcion,
                TipoActividad = dto.TipoActividad,
                ContratoId = dto.ContratoId,
                Extra = dto.Extra

            };
        }
    }
}
