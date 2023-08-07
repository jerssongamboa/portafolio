using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
    public static partial class Mapper
    {
        public static ContratoDTO ToDTO(this Contrato model)  // Convierte de ModelContext a DTO
        {
            return new ContratoDTO()
            {
                IdContrato = model.IdContrato,
                ClienteRut = model.ClienteRut,
                Descripcion = model.Descripcion,
                FechaInicio = model.FechaInicio,
                FechaTermino = model.FechaTermino
            };
        }
    }

    public static partial class Mapper
    {
        public static Contrato ToDatabase(this ContratoDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Contrato()
            {
                IdContrato = dto.IdContrato,
                ClienteRut = dto.ClienteRut,
                Descripcion = dto.Descripcion,
                FechaInicio = dto.FechaInicio,
                FechaTermino = dto.FechaTermino
            };
        }
    }

}
