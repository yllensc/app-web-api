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
        public string? Genero { get; set; }
        public int CiudadIdFK { get; set; }
        public int TipoPersonaIdFK { get; set; }
        public TipoPersona? TipoPersonas { get; set; }
         public int RegionId { get; set; }
        public Region? Regiones { get; set; }
        public ICollection<TrainerSalon>? TrainersSalones { get; set; }
        public ICollection<Matricula>? Matriculas { get; set; }

    }
