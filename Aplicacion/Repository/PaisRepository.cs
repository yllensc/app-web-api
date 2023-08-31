using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        public PaisRepository(AppWebApiContext context) : base(context)
        {
            
        }
    }
