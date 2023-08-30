using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Salon : BaseEntity
    {
        public string? NombreSalon { get; set; }
        public int Capacidad { get; set; }
        public ICollection<TrainerSalon>? TrainersSalones { get; set; }
        public ICollection<Matricula>? Matriculas { get; set; }

    }
