using System.Collections.Generic;
using WebApplicationTechLead1.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApplicationTechLead1.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        // Configurar o provedor de configuração
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        // Configurar a conexão com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Obter a cadeia de conexão do arquivo appsettings.json
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
