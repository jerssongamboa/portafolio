using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IReporteService
    {
        Task<RespuestaService<List<Reporte>>> Listar();

        Task<RespuestaService<Reporte>> BuscarPorId(decimal id);

        Task<RespuestaService<Reporte>> Guardar(Reporte c);

        Task<RespuestaService<Reporte>> Actualizar(Reporte c);

        Task<RespuestaService<bool>> Eliminar(decimal id);

    }
}
