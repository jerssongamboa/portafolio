using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class AdministradorService : IAdministradorService
    {

        private ModelContext _context;

        public AdministradorService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Administrador>> Actualizar(Administrador c)
        {
            var res = new RespuestaService<Administrador>();
            var cat = await _context.Administradors.FirstOrDefaultAsync(x => x.Rut == c.Rut);

            if (cat == null)
                res.AgregarBadRequest("El rut recibido no está registrado");
            else
            {

                cat.Nombre = c.Nombre;
                cat.ApellidoPaterno = c.ApellidoPaterno;
                cat.ApellidoMaterno = c.ApellidoMaterno;
                cat.Telefono = c.Telefono;
                cat.EstadousuarioId = c.EstadousuarioId;

                try
                {
                    _context.Administradors.Update(cat);
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

        public async Task<RespuestaService<Administrador>> BuscarPorRut(string rut)
        {
            var res = new RespuestaService<Administrador>();
            var cat = await _context.Administradors.FirstOrDefaultAsync(x => x.Rut == rut);

            if (cat == null)
                res.AgregarBadRequest("El rut recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(string rut)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Administradors.FirstOrDefaultAsync(x => x.Rut == rut);

            if (cat == null)
                res.AgregarBadRequest("El rut recibido no está registrado");
            else
            {
                try
                {
                    _context.Administradors.Remove(cat);
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
        public async Task<RespuestaService<Administrador>> Guardar(Administrador c)
        {
            var res = new RespuestaService<Administrador>();

            try
            {
                await _context.Administradors.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Rut = await _context.Administradors.MaxAsync(u => u.Rut);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Administrador>>> Listar()
        {
            var res = new RespuestaService<List<Administrador>>();
            var lista = await _context.Administradors.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
