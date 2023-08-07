using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IEstadoEstadoPagoService
    {
        Task<RespuestaService<List<Estadopago>>> Listar();

        Task<RespuestaService<Estadopago>> BuscarPorId(int id);

        Task<RespuestaService<Estadopago>> Guardar(Estadopago c);

        Task<RespuestaService<Estadopago>> Actualizar(Estadopago c);

        Task<RespuestaService<bool>> Eliminar(int id);

    }
}
