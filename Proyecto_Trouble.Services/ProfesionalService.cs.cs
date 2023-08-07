using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class ProfesionalService : IProfesionalService
    {

        private ModelContext _context;

        public ProfesionalService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Profesional>> Actualizar(Profesional c)
        {
            var res = new RespuestaService<Profesional>();
            var cat = await _context.Profesionals.FirstOrDefaultAsync(x => x.Rut == c.Rut);

            if (cat == null)
                res.AgregarBadRequest("El rut recibido no está registrado");
            else
            {

                cat.Nombre = c.Nombre;
                cat.ApellidoPaterno = c.ApellidoPaterno;
                cat.ApellidoMaterno = c.ApellidoMaterno;
                cat.Telefono = c.Telefono;
                cat.EstadousuarioId = c.EstadousuarioId;
                cat.ProfesionalActId = c.ProfesionalActId;


                try
                {
                    _context.Profesionals.Update(cat);
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

        public async Task<RespuestaService<Profesional>> BuscarPorRut(string rut)
        {
            var res = new RespuestaService<Profesional>();
            var cat = await _context.Profesionals.FirstOrDefaultAsync(x => x.Rut == rut);

            if (cat == null)
                res.AgregarBadRequest("El rut recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(string rut)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Profesionals.FirstOrDefaultAsync(x => x.Rut == rut);

            if (cat == null)
                res.AgregarBadRequest("El rut recibido no está registrado");
            else
            {
                try
                {
                    _context.Profesionals.Remove(cat);
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
        public async Task<RespuestaService<Profesional>> Guardar(Profesional c)
        {
            var res = new RespuestaService<Profesional>();

            try
            {
                await _context.Profesionals.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Rut = await _context.Profesionals.MaxAsync(u => u.Rut);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Profesional>>> Listar()
        {
            var res = new RespuestaService<List<Profesional>>();
            var lista = await _context.Profesionals.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
