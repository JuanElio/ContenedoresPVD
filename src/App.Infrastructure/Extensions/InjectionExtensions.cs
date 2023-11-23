using App.Domain.Entities;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionRepository(this IServiceCollection services)
        {

            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
            services.AddScoped<IDistritoRepository, DistritoRepository>();
            services.AddScoped<ITipoDocumentoIdentidadRepository, TipoDocumentoIdentidadRepository>();
            services.AddScoped<ITipoPersonaRepository, TipoPersonaRepository>();
            services.AddScoped<IUnidadEjecutoraRepository, UnidadEjecutoraRepository>();
            services.AddScoped<IRedVialNacionalRepository, RedVialNacionalRepository>();
            services.AddScoped<IRedVialNacionalPuntoRepository, RedVialNacionalPuntoRepository>();
            services.AddScoped<ICentroPobladoRepository, CentroPobladoRepository>();
            services.AddScoped<ICentroSaludRepository, CentroSaludRepository>();
            services.AddScoped<IComisariaRepository, ComisariaRepository>();
            services.AddScoped<IColegioRepository, ColegioRepository>();
            services.AddScoped<ITipoDispositivoRepository, TipoDispositivoRepository>();
            services.AddScoped<ITipoInversionRepository, TipoInversionRepository>();
            services.AddScoped<IDispositivoLegalRepository, DispositivoLegalRepository>();
            services.AddScoped<ITipoDocumentalRepository, TipoDocumentalRepository>();
            services.AddScoped<ICalendarioRepository, CalendarioRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();

            //services.AddSingleton<ApplicationDbContext>();

            return services;

        }
    }
}
