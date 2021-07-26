using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo.Colegio;

namespace Persistencia
{
    public class ColegioContext : DbContext
    {

        public DbSet<Alumno> alumnos { get; set; }
        public DbSet<Grado> grados { get; set; }
        public DbSet<Colegio> colegios { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Configuracion> configuracions { get; set; }
        public DbSet<Ciclo> ciclos { get; set; }
        public DbSet<Pago> pagos { get; set; }
        public DbSet<Periodo> periodos { get; set; }
        public DbSet<Valor> valors { get; set; }
        public DbSet<PagoDet> pagoDets  { get; set; }

        // Constructor vacio
        public ColegioContext():base()
        {

        }

        // Constructor para pasar la conexión al padre
        public ColegioContext(DbContextOptions<ColegioContext> opciones)
            : base(opciones)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ColegioConfig.ContextOptions(optionsBuilder);
            }
        }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuracion
            modelBuilder.Entity<Configuracion>()
                .HasOne(config => config.PeriodoV)
                .WithMany()
                .HasForeignKey(config => config.periodoidV);
            // Relación uno a muchos; un Estudiante tiene muchos Pagos 
            modelBuilder.Entity<Pago>()
                .HasOne(pag => pag.Alumno)
                .WithMany(est => est.Pagos)
                .HasForeignKey(pag => pag.AlumnoID);

         
            //// Relación uno a muchos; un Pago tiene un Periodo    
            //modelBuilder.Entity<Pago>()
            //   .HasOne(config => config.Ciclo)
            //   .WithMany()               

            // Relación uno a uno; un Pago tiene un Estado
            modelBuilder.Entity<Pago>()
                .HasOne(est => est.Estado)
                .WithMany()
                .HasForeignKey(pag => pag.EstadoID);                  

            //Relacion uno a muchos ; un grado tiene muchos alumnos
            modelBuilder.Entity<Alumno>()
               .HasOne(p => p.Grado)
               .WithMany(c => c.Alumno)
               .HasForeignKey(p => p.GradeId);
            //Relacion uno a muchos ; un Periodo tiene muchos Ciclos
            modelBuilder.Entity<Ciclo>()
               .HasOne(p => p.periodo)
               .WithMany(c => c.Ciclos)
               .HasForeignKey(p => p.PeriodoID);
            // Relación uno a muchos; en un período se registran varios pagos
            modelBuilder.Entity<Pago>()
                .HasOne(mat => mat.periodo)
                .WithMany(per => per.Pagos)
                .HasForeignKey(mat => mat.PeriodoId);
            // Relación de uno a muchos: cabecera detalle del pago
            modelBuilder.Entity<PagoDet>()
                .HasOne(det => det.Pago)
                .WithMany(mat => mat.PagoDets)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(det => det.PagoId);
            // Relación de uno a muchos: Ciclos con detalles del pago
            modelBuilder.Entity<PagoDet>()
                .HasOne(det => det.Ciclo)
                .WithMany(cur => cur.PagoDets)
                .HasForeignKey(det => det.CicloId);
            // Relación uno a uno; una PagoDet tiene un valores de pago
            modelBuilder.Entity<PagoDet>()
                .HasOne(det => det.Valor)
                .WithOne(val => val.PagoDet)
                .HasForeignKey<Valor>(val => val.PagoDetId);
            // Relación uno a muchos; un Período tiene varios ciclos
            modelBuilder.Entity<Ciclo>()
                .HasOne(cur => cur.periodo)
                .WithMany(per => per.Ciclos)
                .HasForeignKey(cur => cur.PeriodoID);
          
        }
    }
}
