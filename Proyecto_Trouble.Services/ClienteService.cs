using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class ClienteService : IClienteService
    {

        private ModelContext _context;

        public ClienteService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Cliente>> Actualizar(Cliente c)
        {
            var res = new RespuestaService<Cliente>();
            var cat = await _context.Clientes.FirstOrDefaultAsync(x => x.Rut == c.Rut);

            if (cat == null)
                res.AgregarBadRequest("El rut recibido no está registrado");
            else
            {

                cat.Telefono = c.Telefono;
                cat.EstadousuarioId = c.EstadousuarioId;

                try
                {
                    _context.Clientes.Update(cat);
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

        public async Task<RespuestaService<Cliente>> BuscarPorRut(string rut)
        {
            var res = new RespuestaService<Cliente>();
            var cat = await _context.Clientes.FirstOrDefaultAsync(x => x.Rut == rut);

            if (cat == null)
                res.AgregarBadRequest("El rut recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(string rut)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Clientes.FirstOrDefaultAsync(x => x.Rut == rut);

            if (cat == null)
                res.AgregarBadRequest("El rut recibido no está registrado");
            else
            {
                try
                {
                    _context.Clientes.Remove(cat);
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
        public async Task<RespuestaService<Cliente>> Guardar(Cliente c)
        {
            var res = new RespuestaService<Cliente>();

            try
            {
                await _context.Clientes.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Rut = await _context.Clientes.MaxAsync(u => u.Rut);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Cliente>>> Listar()
        {
            var res = new RespuestaService<List<Cliente>>();
            var lista = await _context.Clientes.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
