using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Estado: BaseEntity
    {
        public string? NombreEstado { get; set; }
        public int IdPaisFK { get; set; }
        public Pais? Pais { get; set; }
        public ICollection<Region>? Regiones { get; set; }
    }
