global using Microsoft.EntityFrameworkCore;
using API_Consultorio.Model;

namespace API_Consultorio.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Paciente> Pacientes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //relação 1 consulta para 1 paciente e 1 médico
            modelBuilder.Entity<Consulta>()
                 .HasOne(c => c.Paciente)
                 .WithMany()
                 .HasForeignKey(c => c.PacienteID)
                 .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Consulta>()
                 .HasOne(c => c.Medico)
                 .WithMany()
                 .HasForeignKey(c => c.MedicoID)
                 .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=G15\\SQLEXPRESS;database=consultorioDb;trusted_connection=true;TrustServerCertificate=True");
        }
    }
}
