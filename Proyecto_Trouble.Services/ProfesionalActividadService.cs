using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class ProfesionalactividadService : IProfesionalActividadService
    {

        private ModelContext _context;

        public ProfesionalactividadService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Profesionalactividad>> Actualizar(Profesionalactividad c)
        {
            var res = new RespuestaService<Profesionalactividad>();
            var cat = await _context.Profesionalactividads.FirstOrDefaultAsync(x => x.Id == c.Id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Actividad = c.Actividad;

                try
                {
                    _context.Profesionalactividads.Update(cat);
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

        public async Task<RespuestaService<Profesionalactividad>> BuscarPorId(int id)
        {
            var res = new RespuestaService<Profesionalactividad>();
            var cat = await _context.Profesionalactividads.FirstOrDefaultAsync(x => x.Id == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Profesionalactividads.FirstOrDefaultAsync(x => x.Id == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Profesionalactividads.Remove(cat);
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
        public async Task<RespuestaService<Profesionalactividad>> Guardar(Profesionalactividad c)
        {
            var res = new RespuestaService<Profesionalactividad>();

            try
            {
                await _context.Profesionalactividads.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Id = await _context.Profesionalactividads.MaxAsync(u => u.Id);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Profesionalactividad>>> Listar()
        {
            var res = new RespuestaService<List<Profesionalactividad>>();
            var lista = await _context.Profesionalactividads.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
