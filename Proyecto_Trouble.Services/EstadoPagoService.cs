using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_Trouble.Services
{
        public class EstadoPagoService : IEstadoEstadoPagoService
        {

            private ModelContext _context;

            public EstadoPagoService(ModelContext context)
            {
                _context = context;
            }
            public async Task<RespuestaService<Estadopago>> Actualizar(Estadopago c)
        {
            var res = new RespuestaService<Estadopago>();
            var cat = await _context.Estadopagos.FirstOrDefaultAsync(x => x.Id == c.Id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Nombre = c.Nombre;
                

                try
                {
                    _context.Estadopagos.Update(cat);
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

        public async Task<RespuestaService<Estadopago>> BuscarPorId(int id)
        {
            var res = new RespuestaService<Estadopago>();
            var cat = await _context.Estadopagos.FirstOrDefaultAsync(x => x.Id == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Estadopagos.FirstOrDefaultAsync(x => x.Id == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Estadopagos.Remove(cat);
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
        public async Task<RespuestaService<Estadopago>> Guardar(Estadopago c)
        {
            var res = new RespuestaService<Estadopago>();

            try
            {
                await _context.Estadopagos.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Id = await _context.Estadopagos.MaxAsync(u => u.Id);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Estadopago>>> Listar()
        {
            var res = new RespuestaService<List<Estadopago>>();
            var lista = await _context.Estadopagos.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}

