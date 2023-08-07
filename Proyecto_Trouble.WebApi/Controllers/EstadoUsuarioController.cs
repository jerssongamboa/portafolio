using Microsoft.AspNetCore.Mvc;
using Proyecto_Trouble.DTO;
using Proyecto_Trouble.Services;
using Proyecto_Trouble.WebApi.Mappings;

namespace Proyecto_Trouble.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadousuarioController : ControllerBase
    {

        private readonly IEstadoUsuarioService _servicio;


        public EstadousuarioController(IEstadoUsuarioService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstadoUsuarioDTO>>> Listar()
        {
            var retorno = await _servicio.Listar();

            if (retorno.Objeto != null)
                return retorno.Objeto.Select(Mapper.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoUsuarioDTO>> BuscarPorId(decimal id)
        {
            var retorno = await _servicio.BuscarPorId(id);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPost]
        public async Task<ActionResult<EstadoUsuarioDTO>> Guardar(EstadoUsuarioDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<EstadoUsuarioDTO>> Actualizar(EstadoUsuarioDTO c)
        {
            var retorno = await _servicio.Actualizar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Eliminar(decimal id)
        {
            {
                var retorno = await _servicio.Eliminar(id);

                if (retorno.Exito)
                    return true;
                else
                    return StatusCode(retorno.Status, retorno.Error);
            }
        }


    }
}
