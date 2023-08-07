using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
    public static partial class Mapper
    {
        public static ProfesionalDTO ToDTO(this Profesional model)  // Convierte de ModelContext a DTO
        {
            return new ProfesionalDTO()
            {
                Rut = model.Rut,
                Nombre = model.Nombre,
                ApellidoPaterno = model.ApellidoPaterno,
                ApellidoMaterno = model.ApellidoMaterno,
                Telefono = model.Telefono,
                Correo = model.Correo,
                Direccion = model.Direccion,
                ComunaIdComuna = model.ComunaIdComuna,
                RegionIdRegion = model.RegionIdRegion,
                Contrasena = model.Contrasena,
                TipousuarioId = model.TipousuarioId,
                EstadousuarioId = model.EstadousuarioId,
                ProfesionalActId = model.ProfesionalActId
            };
        }
    }

    public static partial class Mapper
    {
        public static Profesional ToDatabase(this ProfesionalDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Profesional()
            {
                Rut = dto.Rut,
                Nombre = dto.Nombre,
                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno = dto.ApellidoMaterno,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Direccion = dto.Direccion,
                ComunaIdComuna = dto.ComunaIdComuna,
                RegionIdRegion = dto.RegionIdRegion,
                Contrasena = dto.Contrasena,
                TipousuarioId = dto.TipousuarioId,
                EstadousuarioId = dto.EstadousuarioId,
                ProfesionalActId = dto.ProfesionalActId
            };
        }
    }
}
