using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
    public static partial class Mapper
    {
        public static ComunaDTO ToDTO(this Comuna model)  // Convierte de ModelContext a DTO
        {
            return new ComunaDTO()
            {
                IdComuna = model.IdComuna,
                Nombre = model.Nombre,
                IdRegion = model.IdRegion
            };
        }
    }

    public static partial class Mapper
    {
        public static Comuna ToDatabase(this ComunaDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Comuna()
            {
                IdComuna = dto.IdComuna,
                Nombre = dto.Nombre,
                IdRegion = dto.IdRegion

            };
        }
    }
}
