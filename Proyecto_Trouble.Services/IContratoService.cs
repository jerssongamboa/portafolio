using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public interface IcontratoService
    {
        Task<RespuestaService<List<Contrato>>> Listar();

        Task<RespuestaService<Contrato>> BuscarPorId(string id);

        Task<RespuestaService<Contrato>> Guardar(Contrato c);

        Task<RespuestaService<Contrato>> Actualizar(Contrato c);

        Task<RespuestaService<bool>> Eliminar(string id);

    }
}