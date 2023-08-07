using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IClienteService
    {
        Task<RespuestaService<List<Cliente>>> Listar();

        Task<RespuestaService<Cliente>> BuscarPorRut(string rut);

        Task<RespuestaService<Cliente>> Guardar(Cliente c);

        Task<RespuestaService<Cliente>> Actualizar(Cliente c);

        Task<RespuestaService<bool>> Eliminar(string rut);
    }
}
