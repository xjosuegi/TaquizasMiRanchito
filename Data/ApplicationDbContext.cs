using AgendaPrueva1.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AgendaPrueva1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Guizo> Guizos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Pagos)
                .WithOne(p => p.Evento)
                .HasForeignKey(p => p.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Guizos)
                .WithOne(g => g.Evento)
                .HasForeignKey(g => g.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración específica para MySQL
            modelBuilder.Entity<Evento>(entity =>
            {
                entity.Property(e => e.PrecioTotal)
                      .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(p => p.Monto)
                      .HasColumnType("decimal(18,2)");
            });
        }
    }
}