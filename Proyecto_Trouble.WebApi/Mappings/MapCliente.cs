using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
    public static partial class Mapper
    {
        public static ClienteDTO ToDTO(this Cliente model)  // Convierte de ModelContext a DTO
        {
            return new ClienteDTO()
            {
                Rut = model.Rut,
                RazonSocial = model.RazonSocial,
                Rubro = model.Rubro,
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
        public static Cliente ToDatabase(this ClienteDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Cliente()
            {
                Rut = dto.Rut,
                RazonSocial = dto.RazonSocial,
                Rubro = dto.Rubro,
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
