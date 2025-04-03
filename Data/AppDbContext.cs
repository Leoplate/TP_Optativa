namespace TP1.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Configuration;
    using TP1.Models;

    public class AppDbContext : DbContext
    {
        
        
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        
        public DbSet<Cliente> Clientes { get; set; } // Representa la tabla 'Cliente'

        
    }

}
