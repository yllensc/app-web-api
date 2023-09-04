using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppWebApiContext context ;
        private PaisRepository _paises;
        private EstadoRepository _estados;
        private RegionRepository _regiones;

        public UnitOfWork(AppWebApiContext _context)
        {
            this.context = _context;
        }

        public IPais Paises
        {
            get{
                if(_paises == null){
                    _paises = new PaisRepository(context);
                }
                return _paises;
            }
        }

        public IEstado Estados{
            get{
                if(_estados == null){
                    _estados = new EstadoRepository(context);
                }
                return _estados;
            }
        }

        public IRegion Regiones{
            get{
                if(_regiones == null){
                    _regiones = new RegionRepository(context);
                }
                return _regiones;
            }
        }

        /* public int Save(){
            return context.SaveChanges();
        } */

        public void Dispose()
        {
            context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}