using App.Domain.Entities;
using App.ModelDto.DTOs;
using AutoMapper;
namespace Editora.AppInfrastructure.Profiles
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            //
            CreateMap<Articulo, ArticuloDTO>();
            CreateMap<ArticuloDTO, Articulo>();

            //
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            //
            CreateMap<Proveedor, ProveedorDTO>();
            CreateMap<ProveedorDTO, Proveedor>();

            //
            CreateMap<Persona, PersonaDTO>();
            CreateMap<PersonaDTO, Persona>();

            //
            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<DepartamentoDTO, Departamento>();

            //
            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<ProvinciaDTO, Provincia>();

            //
            CreateMap<Distrito, DistritoDTO>();
            CreateMap<DistritoDTO, Distrito>();

            CreateMap<TipoDocumentoIdentidad, TipoDocumentoIdentidadDTO>();
            CreateMap<TipoDocumentoIdentidadDTO, TipoDocumentoIdentidad>();

            CreateMap<TipoPersona, TipoPersonaDTO>();
            CreateMap<TipoPersonaDTO, TipoPersona>();

            CreateMap<UnidadEjecutora, UnidadEjecutoraDTO>();
            CreateMap<UnidadEjecutoraDTO, UnidadEjecutora>();

            CreateMap<RedVialNacional, RedVialNacionalDTO>();
            CreateMap<RedVialNacionalDTO, RedVialNacional>();

            CreateMap<RedVialNacionalPunto, RedVialNacionalPuntoDTO>();
            CreateMap<RedVialNacionalPuntoDTO, RedVialNacionalPunto>();

            CreateMap<CentroPoblado, CentroPobladoDTO>();
            CreateMap<CentroPobladoDTO, CentroPoblado>();

            CreateMap<CentroSalud, CentroSaludDTO>();
            CreateMap<CentroSaludDTO, CentroSalud>();

            CreateMap<TipoDispositivo, TipoDispositivoDTO>();
            CreateMap<TipoDispositivoDTO, TipoDispositivo>();

            CreateMap<TipoInversion, TipoInversionDTO>();
            CreateMap<TipoInversionDTO, TipoInversion>();

            CreateMap<DispositivoLegal, DispositivoLegalDTO>();
            CreateMap<DispositivoLegalDTO, DispositivoLegal>();

            CreateMap<Calendario, CalendarioDTO>();
            CreateMap<CalendarioDTO, Calendario>();

            CreateMap<Pais, PaisDTO>();
            CreateMap<PaisDTO, Pais>();

        }
    }
}
