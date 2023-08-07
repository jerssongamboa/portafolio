using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IProfesionalService
    {
        Task<RespuestaService<List<Profesional>>> Listar();

        Task<RespuestaService<Profesional>> BuscarPorRut(string rut);

        Task<RespuestaService<Profesional>> Guardar(Profesional c);

        Task<RespuestaService<Profesional>> Actualizar(Profesional c);

        Task<RespuestaService<bool>> Eliminar(string rut);
    }
}
