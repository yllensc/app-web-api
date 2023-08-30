using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class TrainerSalon
    {
        public int IdPersonaFK { get; set; }
        public Persona? Persona { get; set; }
        public int IdSalonFK { get; set; }
        public Salon? Salones { get; set; }    }
}