using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
        public static partial class Mapper
        {
            public static ProfesionalActividadDTO ToDTO(this Profesionalactividad model)  // Convierte de ModelContext a DTO
            {
                return new ProfesionalActividadDTO()
                {
                    Id = model.Id,
                    Actividad = model.Actividad,
                  

                };
            }
        }

        public static partial class Mapper
        {
            public static Profesionalactividad ToDatabase(this ProfesionalActividadDTO dto)  // Convierte de DTO a ModelContext
            {
                return new Profesionalactividad()
                {

                    Id = dto.Id,
                    Actividad = dto.Actividad,


                };
            }
        }
}
