using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        
        protected readonly AppWebApiContext _context;
        public PaisRepository(AppWebApiContext context) : base(context)
        {
            _context = context;
        }
        
        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises
                .Include(p => p.Estados)//.ThenInclude(c => c.Regiones)
                .ToListAsync();
        }

        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
            .Include(p => p.Estados)
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
        }
    
