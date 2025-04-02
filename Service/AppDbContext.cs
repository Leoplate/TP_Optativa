namespace TP1.Service
{
    using Microsoft.EntityFrameworkCore;
    using System.Configuration;
    using TP1.Models;

    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } // Representa la tabla 'Cliente'

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var connetionString = "Server=localhost;Database=clientes;User=root;Password=Chiyan71;";
                optionsBuilder.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
                //optionsBuilder.UseMySql(
                //    "Server=localhost;Database=clientes;User=root;Password=Chiyan71;",
                //    new MySqlServerVersion(new Version(8, 0, 41)) // Cambia según la versión de tu servidor MySQL
                //);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .ToTable("cliente"); // Asegúrate de que coincide con el nombre de tu tabla en MySQL
        }
    }

}
