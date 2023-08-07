using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class ActividadeService : IActividadeService
    {

        private ModelContext _context;

        public ActividadeService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Actividade>> Actualizar(Actividade c)
        {
            var res = new RespuestaService<Actividade>();
            var cat = await _context.Actividades.FirstOrDefaultAsync(x => x.IdActividad == c.IdActividad);

            if (cat == null)
                res.AgregarBadRequest("El Id recibido no está registrado");
            else
            {

                cat.Descripcion = c.Descripcion;
                cat.FechaTerminoReal = c.FechaTerminoReal;

                try
                {
                    _context.Actividades.Update(cat);
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

        public async Task<RespuestaService<Actividade>> BuscarId(decimal IdActividade)
        {
            var res = new RespuestaService<Actividade>();
            var cat = await _context.Actividades.FirstOrDefaultAsync(x => x.IdActividad == IdActividade);

            if (cat == null)
                res.AgregarBadRequest("El Id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal IdActividade)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Actividades.FirstOrDefaultAsync(x => x.IdActividad == IdActividade);

            if (cat == null)
                res.AgregarBadRequest("El Id recibido no está registrado");
            else
            {
                try
                {
                    _context.Actividades.Remove(cat);
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
        public async Task<RespuestaService<Actividade>> Guardar(Actividade c)
        {
            var res = new RespuestaService<Actividade>();

            try
            {
                await _context.Actividades.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdActividad = await _context.Actividades.MaxAsync(u => u.IdActividad);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Actividade>>> Listar()
        {
            var res = new RespuestaService<List<Actividade>>();
            var lista = await _context.Actividades.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
