using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class EstadoRepository: GenericRepository<Estado>, IEstado
    {
        protected readonly AppWebApiContext _context;

        public EstadoRepository(AppWebApiContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await this._context.Estados
                .Include(d => d.Regiones)
                .ToListAsync();
        }

        public override async Task<Estado> GetByIdAsync(int id)
        {
            return await this._context.Estados
            .Include(d => d.Regiones)
            .FirstOrDefaultAsync(d => d.Id == id);
        }
        
    }
}