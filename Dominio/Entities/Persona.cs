using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Persona : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set;}
        public string? Direccion { get; set; }
        public string? IdGeneroFK { get; set; }
        public Genero? Genero { get; set; }
        public int TipoPersonaIdFK { get; set; }
        public TipoPersona? TipoPersona { get; set; }
         public int IdRegionFK { get; set; }
        public Region? Region { get; set; }
        public ICollection<TrainerSalon>? TrainersSalones { get; set; }
        public ICollection<Matricula>? Matriculas { get; set; }

    }
