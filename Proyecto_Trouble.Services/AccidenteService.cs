using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class AccidenteService : IAccidenteService
    {

        private ModelContext _context;

        public AccidenteService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Accidente>> Actualizar(Accidente c)
        {
            var res = new RespuestaService<Accidente>();
            var cat = await _context.Accidentes.FirstOrDefaultAsync(x => x.IdAccidente == c.IdAccidente);

            if (cat == null)
                res.AgregarBadRequest("El Id recibido no está registrado");
            else
            {

                cat.Descripcion = c.Descripcion;

                try
                {
                    _context.Accidentes.Update(cat);
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

        public async Task<RespuestaService<Accidente>> BuscarId(decimal IdAccidente)
        {
            var res = new RespuestaService<Accidente>();
            var cat = await _context.Accidentes.FirstOrDefaultAsync(x => x.IdAccidente == IdAccidente);

            if (cat == null)
                res.AgregarBadRequest("El Id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal IdAccidente)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Accidentes.FirstOrDefaultAsync(x => x.IdAccidente == IdAccidente);

            if (cat == null)
                res.AgregarBadRequest("El Id recibido no está registrado");
            else
            {
                try
                {
                    _context.Accidentes.Remove(cat);
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
        public async Task<RespuestaService<Accidente>> Guardar(Accidente c)
        {
            var res = new RespuestaService<Accidente>();

            try
            {
                await _context.Accidentes.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdAccidente = await _context.Accidentes.MaxAsync(u => u.IdAccidente);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Accidente>>> Listar()
        {
            var res = new RespuestaService<List<Accidente>>();
            var lista = await _context.Accidentes.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
