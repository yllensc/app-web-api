using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
    public class RegionRepository: GenericRepository<Region>, IRegion
    {
        
        protected readonly AppWebApiContext _context;
        public RegionRepository(AppWebApiContext context) : base(context)
        {
            _context = context;
        }
        
        public override async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regiones
                .ToListAsync();
        }

        public override async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Regiones
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
        }