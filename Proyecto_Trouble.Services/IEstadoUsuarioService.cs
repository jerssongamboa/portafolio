using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IEstadoUsuarioService
    {
        Task<RespuestaService<List<Estadousuario>>> Listar();

        Task<RespuestaService<Estadousuario>> BuscarPorId(decimal id);

        Task<RespuestaService<Estadousuario>> Guardar(Estadousuario c);

        Task<RespuestaService<Estadousuario>> Actualizar(Estadousuario c);

        Task<RespuestaService<bool>> Eliminar(decimal id);
    }
}
