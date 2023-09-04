using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        IPais Paises { get; }
        //IEstado Estados { get; }
        Task<int> SaveAsync();
    }
}