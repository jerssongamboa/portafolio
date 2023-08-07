using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{

    public static partial class Mapper
    {
        public static TipousuarioDTO ToDTO(this Tipousuario model)  // Convierte de ModelContext a DTO
        {
            return new TipousuarioDTO()
            {
                Id = model.Id,
                Nombre = model.Nombre
            };
        }
    }

    public static partial class Mapper
    {
        public static Tipousuario ToDatabase(this TipousuarioDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Tipousuario()
            {
                Id = dto.Id,
                Nombre = dto.Nombre

            };
        }
    }
}
