using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class ComunaService : IComunaService
    {

        private ModelContext _context;

        public ComunaService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Comuna>> Actualizar(Comuna c)
        {
            var res = new RespuestaService<Comuna>();
            var cat = await _context.Comunas.FirstOrDefaultAsync(x => x.IdComuna == c.IdComuna);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Nombre = c.Nombre;

                try
                {
                    _context.Comunas.Update(cat);
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

        public async Task<RespuestaService<Comuna>> BuscarPorId(decimal id)
        {
            var res = new RespuestaService<Comuna>();
            var cat = await _context.Comunas.FirstOrDefaultAsync(x => x.IdComuna == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Comunas.FirstOrDefaultAsync(x => x.IdComuna == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Comunas.Remove(cat);
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
        public async Task<RespuestaService<Comuna>> Guardar(Comuna c)
        {
            var res = new RespuestaService<Comuna>();

            try
            {
                await _context.Comunas.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdComuna = await _context.Comunas.MaxAsync(u => u.IdComuna);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Comuna>>> Listar()
        {
            var res = new RespuestaService<List<Comuna>>();
            var lista = await _context.Comunas.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
