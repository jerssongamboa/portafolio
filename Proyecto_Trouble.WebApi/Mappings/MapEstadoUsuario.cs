using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
    public static partial class Mapper
    {
        public static EstadoUsuarioDTO ToDTO(this Estadousuario model)  // Convierte de ModelContext a DTO
        {
            return new EstadoUsuarioDTO()
            {
                Id = model.Id,
                Nombre = model.Nombre
            };
        }
    }

    public static partial class Mapper
    {
        public static Estadousuario ToDatabase(this EstadoUsuarioDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Estadousuario()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }
    }
}
