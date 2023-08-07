using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IActividadeService
    {
        Task<RespuestaService<List<Actividade>>> Listar();

        Task<RespuestaService<Actividade>> BuscarId(decimal IdActividad);

        Task<RespuestaService<Actividade>> Guardar(Actividade c);

        Task<RespuestaService<Actividade>> Actualizar(Actividade c);

        Task<RespuestaService<bool>> Eliminar(decimal IdActividad);
    }
}
