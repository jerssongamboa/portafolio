using Microsoft.AspNetCore.Mvc;
using Proyecto_Trouble.DTO;
using Proyecto_Trouble.Services;
using Proyecto_Trouble.WebApi.Mappings;

namespace Proyecto_Trouble.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccidenteController : ControllerBase
    {

        private readonly IAccidenteService _servicio;

        public AccidenteController(IAccidenteService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccidenteDTO>>> Listar()
        {
            var retorno = await _servicio.Listar();

            if (retorno.Objeto != null)
                return retorno.Objeto.Select(Mapper.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpGet("{IdAccidente}")]
        public async Task<ActionResult<AccidenteDTO>> BuscarId(decimal IdAccidente)
        {
            var retorno = await _servicio.BuscarId(IdAccidente);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPost]
        public async Task<ActionResult<AccidenteDTO>> Guardar(AccidenteDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<AccidenteDTO>> Actualizar(AccidenteDTO c)
        {
            var retorno = await _servicio.Actualizar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpDelete("{IdAccidente}")]
        public async Task<ActionResult<bool>> Eliminar(decimal IdAccidente)
        {
            {
                var retorno = await _servicio.Eliminar(IdAccidente);

                if (retorno.Exito)
                    return true;
                else
                    return StatusCode(retorno.Status, retorno.Error);
            }
        }


    }
}
