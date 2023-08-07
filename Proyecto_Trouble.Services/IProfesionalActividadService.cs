using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IProfesionalActividadService
    {
        Task<RespuestaService<List<Profesionalactividad>>> Listar();

        Task<RespuestaService<Profesionalactividad>> BuscarPorId(int id);

        Task<RespuestaService<Profesionalactividad>> Guardar(Profesionalactividad c);

        Task<RespuestaService<Profesionalactividad>> Actualizar(Profesionalactividad c);

        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
