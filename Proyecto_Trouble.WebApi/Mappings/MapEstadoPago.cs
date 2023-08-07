using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{

    public static partial class Mapper
    {
        public static EstadoPagoDTO ToDTO(this Estadopago model)  // Convierte de ModelContext a DTO
        {
            return new EstadoPagoDTO()
            {
                Id = model.Id,
                Nombre = model.Nombre
             };
        }
    }

    public static partial class Mapper
    {
        public static Estadopago ToDatabase(this EstadoPagoDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Estadopago()
            {
                Id = dto.Id,
                Nombre = dto.Nombre

            };
        }
    }

}
