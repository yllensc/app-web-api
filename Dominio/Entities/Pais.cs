using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Pais : BaseEntity
    {
        public string? NombrePais { get; set; }
        public ICollection<Estado>? Estados { get; set; }

}