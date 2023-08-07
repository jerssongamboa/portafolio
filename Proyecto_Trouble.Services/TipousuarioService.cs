using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;

namespace Proyecto_Trouble.Services
{
    public class TipousuarioService : ITipousuarioService
    {

        private ModelContext _context;

        public TipousuarioService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Tipousuario>> Actualizar(Tipousuario c)
        {
            var res = new RespuestaService<Tipousuario>();
            var cat = await _context.Tipousuarios.FirstOrDefaultAsync(x => x.Id == c.Id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Nombre = c.Nombre;

                try
                {
                    _context.Tipousuarios.Update(cat);
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

        public async Task<RespuestaService<Tipousuario>> BuscarPorId(decimal id)
        {
            var res = new RespuestaService<Tipousuario>();
            var cat = await _context.Tipousuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Tipousuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Tipousuarios.Remove(cat);
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
        public async Task<RespuestaService<Tipousuario>> Guardar(Tipousuario c)
        {
            var res = new RespuestaService<Tipousuario>();

            try
            {
                await _context.Tipousuarios.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Id = await _context.Tipousuarios.MaxAsync(u => u.Id);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Tipousuario>>> Listar()
        {
            var res = new RespuestaService<List<Tipousuario>>();
            var lista = await _context.Tipousuarios.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
