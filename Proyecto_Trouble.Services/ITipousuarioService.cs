using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface ITipousuarioService
    {
        Task<RespuestaService<List<Tipousuario>>> Listar();

        Task<RespuestaService<Tipousuario>> BuscarPorId(decimal id);

        Task<RespuestaService<Tipousuario>> Guardar(Tipousuario c);

        Task<RespuestaService<Tipousuario>> Actualizar(Tipousuario c);

        Task<RespuestaService<bool>> Eliminar(decimal id);

    }
}
