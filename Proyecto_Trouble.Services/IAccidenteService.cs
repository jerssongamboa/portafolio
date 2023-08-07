using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IAccidenteService
    {
        Task<RespuestaService<List<Accidente>>> Listar();

        Task<RespuestaService<Accidente>> BuscarId(decimal IdAccidente);

        Task<RespuestaService<Accidente>> Guardar(Accidente c);

        Task<RespuestaService<Accidente>> Actualizar(Accidente c);

        Task<RespuestaService<bool>> Eliminar(decimal IdAccidente);

    }
}
