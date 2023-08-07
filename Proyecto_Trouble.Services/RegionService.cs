using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class RegionService : IRegionService
    {

        private ModelContext _context;

        public RegionService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Region>> Actualizar(Region c)
        {
            var res = new RespuestaService<Region>();
            var cat = await _context.Regions.FirstOrDefaultAsync(x => x.IdRegion == c.IdRegion);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Nombre = c.Nombre;

                try
                {
                    _context.Regions.Update(cat);
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

        public async Task<RespuestaService<Region>> BuscarPorId(decimal id)
        {
            var res = new RespuestaService<Region>();
            var cat = await _context.Regions.FirstOrDefaultAsync(x => x.IdRegion == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Regions.FirstOrDefaultAsync(x => x.IdRegion == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Regions.Remove(cat);
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
        public async Task<RespuestaService<Region>> Guardar(Region c)
        {
            var res = new RespuestaService<Region>();

            try
            {
                await _context.Regions.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdRegion = await _context.Regions.MaxAsync(u => u.IdRegion);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Region>>> Listar()
        {
            var res = new RespuestaService<List<Region>>();
            var lista = await _context.Regions.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
