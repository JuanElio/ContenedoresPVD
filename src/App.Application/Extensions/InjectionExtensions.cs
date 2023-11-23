using App.Application.Interfaces;
using App.Application.Services;
using App.ModelDto.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace App.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
        {
            //services.AddSingleton(configuration);
            //BEGIN CONFIGURATIONS

            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<IArticuloService, ArticuloService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IProvinciaService, ProvinciaService>();
            services.AddScoped<IDistritoService, DistritoService>();
            services.AddScoped<ITipoDocumentoIdentidadService, TipoDocumentoIdentidadService>();
            services.AddScoped<ITipoPersonaService, TipoPersonaService>();
            services.AddScoped<IUnidadEjecutoraService, UnidadEjecutoraService>();
            services.AddScoped<IRedVialNacionalService, RedVialNacionalService>();
            services.AddScoped<IRedVialNacionalPuntoService, RedVialNacionalPuntoService>();
            services.AddScoped<ICentroPobladoService, CentroPobladoService>();
            services.AddScoped<ICentroSaludService, CentroSaludService>();
            services.AddScoped<IComisariaService, ComisariaService>();
            services.AddScoped<IColegioService, ColegioService>();
            services.AddScoped<ITipoDispositivoService, TipoDispositivoService>();
            services.AddScoped<ITipoInversionService, TipoInversionService>();
            services.AddScoped<IDispositivoLegalService, DispositivoLegalService>();
            services.AddScoped<ITipoDispositivoService, TipoDispositivoService>();
            services.AddScoped<ITipoDocumentalService, TipoDocumentalService>();
            services.AddScoped<ICalendarioService, CalendarioService>();
            services.AddScoped<IPaisService, PaisService>();

            return services;
        }
    }
}
