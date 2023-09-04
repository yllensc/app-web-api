using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PaisAllDataDto
    {
        public int PaisId { get; set;}
        public string PaisNombre { get; set; }
        public List<EstadoDto> Departamentos { get; set; } 
    }
}