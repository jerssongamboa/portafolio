using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trouble.Services
{
    public class ContratoService : IcontratoService
    {
        private ModelContext _context;

        public ContratoService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Contrato>> Actualizar(Contrato c)
        {
            var res = new RespuestaService<Contrato>();
            var cat = await _context.Contratos.FirstOrDefaultAsync(x => x.IdContrato == c.IdContrato);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Descripcion = c.Descripcion;
                try
                {
                    _context.Contratos.Update(cat);
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

        public async Task<RespuestaService<Contrato>> BuscarPorId(string id)
        {
            var res = new RespuestaService<Contrato>();
            var cat = await _context.Contratos.FirstOrDefaultAsync(x => x.IdContrato == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(string id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _context.Contratos.FirstOrDefaultAsync(x => x.IdContrato == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Contratos.Remove(cat);
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
        public async Task<RespuestaService<Contrato>> Guardar(Contrato c)
        {
            var res = new RespuestaService<Contrato>();

            try
            {
                await _context.Contratos.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdContrato = await _context.Contratos.MaxAsync(u => u.IdContrato);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Contrato>>> Listar()
        {
            var res = new RespuestaService<List<Contrato>>();
            var lista = await _context.Contratos.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}

