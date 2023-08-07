using Microsoft.AspNetCore.Mvc;
using Proyecto_Trouble.DTO;
using Proyecto_Trouble.Services;
using Proyecto_Trouble.WebApi.Mappings;

namespace Proyecto_Trouble.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {

        private readonly IAdministradorService _servicio;


        public AdministradorController(IAdministradorService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdministradorDTO>>> Listar()
        {
            var retorno = await _servicio.Listar();

            if (retorno.Objeto != null)
                return retorno.Objeto.Select(Mapper.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpGet("{rut}")]
        public async Task<ActionResult<AdministradorDTO>> BuscarPorRut(string rut)
        {
            var retorno = await _servicio.BuscarPorRut(rut);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPost]
        public async Task<ActionResult<AdministradorDTO>> Guardar(AdministradorDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<AdministradorDTO>> Actualizar(AdministradorDTO c)
        {
            var retorno = await _servicio.Actualizar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpDelete("{rut}")]
        public async Task<ActionResult<bool>> Eliminar(string rut)
        {
            {
                var retorno = await _servicio.Eliminar(rut);

                if (retorno.Exito)
                    return true;
                else
                    return StatusCode(retorno.Status, retorno.Error);
            }
        }


    }
}
