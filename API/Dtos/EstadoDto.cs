using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EstadoDto
    {
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set;}
        public List<RegionDto> Ciudades { get; set; } 
        public int IPaisFk { get; set; }
    }
}