using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IRegionService
    {
        Task<RespuestaService<List<Region>>> Listar();

        Task<RespuestaService<Region>> BuscarPorId(decimal id);

        Task<RespuestaService<Region>> Guardar(Region c);

        Task<RespuestaService<Region>> Actualizar(Region c);

        Task<RespuestaService<bool>> Eliminar(decimal id);
    }
}
