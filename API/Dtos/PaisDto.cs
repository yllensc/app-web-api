using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace API.Dtos
{
    public class PaisDto
    {
        public int PaisId { get; set;}
        public string PaisNombre { get; set; }
        public List<EstadoDto> Departamentos { get; set; } 
    }
}