using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Trouble.DataAccess.Models;


namespace Proyecto_Trouble.Services
{
    public interface IPagoService
    {
        Task<RespuestaService<List<Pago>>> Listar();

        Task<RespuestaService<Pago>> BuscarPorId(int id);

        Task<RespuestaService<Pago>> Guardar(Pago c);

        Task<RespuestaService<Pago>> Actualizar(Pago c);

        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
