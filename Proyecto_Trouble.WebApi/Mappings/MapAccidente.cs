using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
    public static partial class Mapper
    {
        public static AccidenteDTO ToDTO(this Accidente model)  // Convierte de ModelContext a DTO
        {
            return new AccidenteDTO()
            {
                IdAccidente = model.IdAccidente,
                ClienteRut = model.ClienteRut,
                FechaAccidente = model.FechaAccidente,
                Descripcion = model.Descripcion

            };
        }
    }

    public static partial class Mapper
    {
        public static Accidente ToDatabase(this AccidenteDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Accidente()
            {
                IdAccidente = dto.IdAccidente,
                ClienteRut = dto.ClienteRut,
                FechaAccidente = dto.FechaAccidente,
                Descripcion = dto.Descripcion
            };
        }
    }
}
