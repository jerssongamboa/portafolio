using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IComunaService
    {
        Task<RespuestaService<List<Comuna>>> Listar();

        Task<RespuestaService<Comuna>> BuscarPorId(decimal id);

        Task<RespuestaService<Comuna>> Guardar(Comuna c);

        Task<RespuestaService<Comuna>> Actualizar(Comuna c);

        Task<RespuestaService<bool>> Eliminar(decimal id);
    }
}
