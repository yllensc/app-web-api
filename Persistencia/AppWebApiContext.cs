using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistencia;
public class AppWebApiContext : DbContext
    {
        public AppWebApiContext(DbContextOptions<AppWebApiContext> options): base(options){

        }
        public DbSet<Pais> Paises { get; set;}
        public DbSet<Estado> Estados { get; set;}
        public DbSet<Region> Regiones { get; set;}
        public DbSet<Persona> Personas { get; set;}
        public DbSet<TipoPersona> TipoPersonas { get; set;}
        public DbSet<Genero> Generos { get; set;}
        public DbSet<Matricula> Matriculas { get; set;}
        public DbSet<Salon> Salones { get; set;}
        public DbSet<TrainerSalon> TrainersSalones { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //assembly está en código binario. contiene uno o más módulos o componentes de código compilado
        }
}