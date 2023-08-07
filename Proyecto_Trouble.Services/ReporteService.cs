using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class ReporteService : IReporteService
    {
        private ModelContext _context;

        public ReporteService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Reporte>> Actualizar(Reporte c)
        {
            var res = new RespuestaService<Reporte>();
            var cat = await _context.Reportes.FirstOrDefaultAsync(x => x.IdReporte == c.IdReporte);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Archivo = c.Archivo;

                try
                {
                    _context.Reportes.Update(cat);
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

        public async Task<RespuestaService<Reporte>> BuscarPorId(decimal id)
        {
            var res = new RespuestaService<Reporte>();
            var cat = await _context.Reportes.FirstOrDefaultAsync(x => x.IdReporte == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Reportes.FirstOrDefaultAsync(x => x.IdReporte == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Reportes.Remove(cat);
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
        public async Task<RespuestaService<Reporte>> Guardar(Reporte c)
        {
            var res = new RespuestaService<Reporte>();

            try
            {
                await _context.Reportes.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdReporte = await _context.Reportes.MaxAsync(u => u.IdReporte);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Reporte>>> Listar()
        {
            var res = new RespuestaService<List<Reporte>>();
            var lista = await _context.Reportes.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}

