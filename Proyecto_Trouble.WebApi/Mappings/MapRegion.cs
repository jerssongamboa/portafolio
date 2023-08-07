using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
    public static partial class Mapper
    {
        public static RegionDTO ToDTO(this Region model)  // Convierte de ModelContext a DTO
        {
            return new RegionDTO()
            {
                IdRegion = model.IdRegion,
                Nombre = model.Nombre
            };
        }
    }

    public static partial class Mapper
    {
        public static Region ToDatabase(this RegionDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Region()
            {
                IdRegion = dto.IdRegion,
                Nombre = dto.Nombre
            };
        }
    }
}
