using App.Domain.Entities;
using App.Infraestruture.Configurations;
using App.Infrastructure.Persistence.Configurations;
using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence.Context
{

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Articulo> Articulo { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Proveedor> Proveedor { get; set; }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<TipoDocumentoIdentidad> TipoDocumentoIdentidad { get; set; }
        public DbSet<TipoPersona> TipoPersona { get; set; }
        public DbSet<UnidadEjecutora> UnidadEjecutora { get; set; }
        public DbSet<RedVialNacional> RedVialNacional { get; set; }
        public DbSet<RedVialNacionalPunto> RedVialNacionalPunto { get; set; }
        public DbSet<CentroPoblado> CentroPoblado { get; set; }
        public DbSet<CentroSalud> CentroSalud { get; set; }
        public DbSet<Comisaria> Comisaria { get; set; }
        public DbSet<Colegio> Colegio { get; set; }
        public DbSet<TipoDispositivo> TipoDispositivo { get; set; }
        public DbSet<TipoInversion> TipoInversion { get; set; }
        public DbSet<DispositivoLegal> DispositivoLegal { get; set; }
        public DbSet<TipoDocumental> TipoDocumental { get; set; }
        public DbSet<Calendario> Calendario { get; set; }
        public DbSet<Pais> Pais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ArticuloConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ProveedorConfiguration());

            //
            modelBuilder.ApplyConfiguration(new PersonaConfiguration());
            //
            modelBuilder.ApplyConfiguration(new DepartamentoConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinciaConfiguration());
            modelBuilder.ApplyConfiguration(new DistritoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoDocumentoIdentidadConfiguration());
            modelBuilder.ApplyConfiguration(new TipoPersonaConfiguration());
            modelBuilder.ApplyConfiguration(new UnidadejecutoraConfiguration());
            modelBuilder.ApplyConfiguration(new RedVialNacionalConfiguration());
            modelBuilder.ApplyConfiguration(new RedVialNacionalPuntoConfiguration());
            modelBuilder.ApplyConfiguration(new CentroPobladoConfiguration());
            modelBuilder.ApplyConfiguration(new CentroSaludConfiguration());
            modelBuilder.ApplyConfiguration(new ComisariaConfiguration());
            modelBuilder.ApplyConfiguration(new ColegioConfiguration());
            modelBuilder.ApplyConfiguration(new TipoDispositivoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoInversionConfiguration());
            modelBuilder.ApplyConfiguration(new DispositivoLegalConfiguration());
            modelBuilder.ApplyConfiguration(new TipoDocumentalConfiguration());
            modelBuilder.ApplyConfiguration(new CalendarioConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }


    //public class ApplicationDbContext2
    //{
    //    private readonly IConfiguration _configuration;
    //    private readonly string _connectionString;
    //    private readonly string _maestrosConnectionString;
    //    private readonly string _pmoConnectionString;

    //    public ApplicationDbContext(IConfiguration configuration)
    //    {
    //        _configuration = configuration;
    //        _connectionString = _configuration.GetConnectionString("SqlDefaultConnection")!;
    //        _maestrosConnectionString= _configuration.GetConnectionString("MaestrosConnection")!;
    //        _pmoConnectionString = _configuration.GetConnectionString("PmoConnection")!;
    //    }

    //    public IDbConnection cn => new SqlConnection(_connectionString);
    //    public IDbConnection cn_maestros => new SqlConnection(_maestrosConnectionString);
    //    public IDbConnection cn_pmo => new SqlConnection(_pmoConnectionString);
    //}

}
