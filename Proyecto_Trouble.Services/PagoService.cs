using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class PagoService : IPagoService
    {

        private ModelContext _context;

        public PagoService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Pago>> Actualizar(Pago c)
        {
            var res = new RespuestaService<Pago>();
            var cat = await _context.Pagos.FirstOrDefaultAsync(x => x.IdPago == c.IdPago);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Monto = c.Monto;
                cat.FechaVencimiento = c.FechaVencimiento;
                cat.IdEstado = c.IdEstado;

                try
                {
                    _context.Pagos.Update(cat);
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

        public async Task<RespuestaService<Pago>> BuscarPorId(int id)
        {
            var res = new RespuestaService<Pago>();
            var cat = await _context.Pagos.FirstOrDefaultAsync(x => x.IdPago == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Pagos.FirstOrDefaultAsync(x => x.IdPago == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Pagos.Remove(cat);
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
        public async Task<RespuestaService<Pago>> Guardar(Pago c)
        {
            var res = new RespuestaService<Pago>();

            try
            {
                await _context.Pagos.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdPago = await _context.Pagos.MaxAsync(u => u.IdPago);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Pago>>> Listar()
        {
            var res = new RespuestaService<List<Pago>>();
            var lista = await _context.Pagos.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
