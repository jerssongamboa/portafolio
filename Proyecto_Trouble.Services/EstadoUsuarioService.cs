using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class EstadousuarioService : IEstadoUsuarioService
    {

        private ModelContext _context;

        public EstadousuarioService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Estadousuario>> Actualizar(Estadousuario c)
        {
            var res = new RespuestaService<Estadousuario>();
            var cat = await _context.Estadousuarios.FirstOrDefaultAsync(x => x.Id == c.Id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Nombre = c.Nombre;

                try
                {
                    _context.Estadousuarios.Update(cat);
                    await _context.SaveChangesAsync();

                    res.Objeto = cat;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<Estadousuario>> BuscarPorId(decimal id)
        {
            var res = new RespuestaService<Estadousuario>();
            var cat = await _context.Estadousuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Estadousuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Estadousuarios.Remove(cat);
                    await _context.SaveChangesAsync();
                    res.Exito = true;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }
        public async Task<RespuestaService<Estadousuario>> Guardar(Estadousuario c)
        {
            var res = new RespuestaService<Estadousuario>();

            try
            {
                await _context.Estadousuarios.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Id = await _context.Estadousuarios.MaxAsync(u => u.Id);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Estadousuario>>> Listar()
        {
            var res = new RespuestaService<List<Estadousuario>>();
            var lista = await _context.Estadousuarios.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
