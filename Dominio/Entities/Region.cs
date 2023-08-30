using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Region: BaseEntity
    {
        public string? RegionName { get; set; }
        public int IdEstadoFK { get; set; }
        public Estado? Estado { get; set; }
        public ICollection<Persona>? Personas { get; set; }
    }
}