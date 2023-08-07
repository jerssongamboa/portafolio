using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
    public static partial class Mapper
    {
        public static AdministradorDTO ToDTO(this Administrador model)  // Convierte de ModelContext a DTO
        {
            return new AdministradorDTO()
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
                EstadousuarioId = model.EstadousuarioId
                
            };
        }
    }

    public static partial class Mapper
    {
        public static Administrador ToDatabase(this AdministradorDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Administrador()
            {
                Rut = dto.Rut,
                Nombre = dto.Nombre,
                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno= dto.ApellidoMaterno,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Direccion = dto.Direccion,
                ComunaIdComuna = dto.ComunaIdComuna,
                RegionIdRegion = dto.RegionIdRegion,
                Contrasena = dto.Contrasena,
                TipousuarioId = dto.TipousuarioId,
                EstadousuarioId = dto.EstadousuarioId
            };
        }
    }
}
