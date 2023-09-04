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
                .Include(p => p.Estados).ThenInclude(c => c.Regiones)
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndex, int pageSize, string search){
            var query = _context.Paises as IQueryable<Pais>;
            if(!string.IsNullOrEmpty(search)){
                query = query.Where(p => p.NombrePais.ToLower().Contains(search.ToLower()));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                .Include(p => p.Estados).ThenInclude(c => c.Regiones)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
            return (totalRegistros, registros);
        }

        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
            .Include(p => p.Estados).ThenInclude(c => c.Regiones)
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
        }
    
