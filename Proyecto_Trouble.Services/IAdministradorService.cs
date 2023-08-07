using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IAdministradorService
    {
        Task<RespuestaService<List<Administrador>>> Listar();

        Task<RespuestaService<Administrador>> BuscarPorRut(string rut);

        Task<RespuestaService<Administrador>> Guardar(Administrador c);

        Task<RespuestaService<Administrador>> Actualizar(Administrador c);

        Task<RespuestaService<bool>> Eliminar(string rut);
    }
}
