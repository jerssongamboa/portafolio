using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.DTO;

namespace Proyecto_Trouble.WebApi.Mappings
{
        public static partial class Mapper
        {
            public static PagoDTO ToDTO(this Pago model)  // Convierte de ModelContext a DTO
            {
                return new PagoDTO()
                {
                    IdPago = model.IdPago,
                    ClienteRut = model.ClienteRut,
                    Monto = model.Monto,
                    FechaVencimiento = model.FechaVencimiento,
                    IdEstado = model.IdEstado

                };
            }
        }

        public static partial class Mapper
        {
            public static Pago ToDatabase(this PagoDTO dto)  // Convierte de DTO a ModelContext
            {
                return new Pago()
                {
                    IdPago = dto.IdPago,
                    ClienteRut = dto.ClienteRut,
                    Monto = dto.Monto,
                    FechaVencimiento = dto.FechaVencimiento,
                    IdEstado = dto.IdEstado

                };
            }
        }

    }
