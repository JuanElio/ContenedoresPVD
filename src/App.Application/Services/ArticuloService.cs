using App.Application.Interfaces;
using App.Domain.Entities;
using App.Infrastructure.Interfaces;
using App.ModelDto.DTOs;
using AutoMapper;

namespace App.Application.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;
        private readonly IMapper _mapper;

        public ArticuloService(IArticuloRepository articuloRepository, IMapper mapper)
        {
            _articuloRepository = articuloRepository;
            _mapper = mapper;
        }

        public async Task Actualizar(ArticuloDTO param)
        {
            var item = _mapper.Map<Articulo>(param);

            /*
            Articulo item = new();

            //Mapper
            item.IdArticulo = param.IdArticulo;
            item.Codigo = param.Codigo;
            item.Nombre = param.Nombre;
            item.UnidadMedida = param.UnidadMedida;
            item.Precio = param.Precio;
            item.FechaIngreso = param.FechaIngreso;
            item.GuidRegistro = param.GuidRegistro;
            item.Creador = param.Creador;
            item.FechaCreacion = param.FechaCreacion;
            item.Modificador    = param.Modificador;
            item.FechaModificacion  = param.FechaModificacion;
            */

            await _articuloRepository.Actualizar(item);

        }

        public async Task<int> Agregar(ArticuloDTO param)
        {
            var item = _mapper.Map<Articulo>(param);

            /*
            Articulo item = new();

            //Mapper
            item.IdArticulo = param.IdArticulo;
            item.Codigo = param.Codigo;
            item.Nombre = param.Nombre;
            item.UnidadMedida = param.UnidadMedida;
            item.Precio = param.Precio;
            item.FechaIngreso = param.FechaIngreso;
            item.GuidRegistro = param.GuidRegistro;
            item.Creador = param.Creador;
            item.FechaCreacion = param.FechaCreacion;
            item.Modificador = param.Modificador;
            item.FechaModificacion = param.FechaModificacion;
            */

            return await _articuloRepository.Agregar(item);

        }

        public async Task<List<ArticuloDTO>> Listar()
        {
            var list = await _articuloRepository.Listar();

            var result = _mapper.Map<List<ArticuloDTO>>(list);

            /*
            var result = new List<ArticuloDTO>();

            foreach (var param in list)
            {
                ArticuloDTO item = new();

                //Mapper
                item.IdArticulo = param.IdArticulo;
                item.Codigo = param.Codigo;
                item.Nombre = param.Nombre;
                item.UnidadMedida = param.UnidadMedida;
                item.Precio = param.Precio;
                item.FechaIngreso = param.FechaIngreso;
                item.GuidRegistro = param.GuidRegistro;
                item.Creador = param.Creador;
                item.FechaCreacion = param.FechaCreacion;
                item.Modificador = param.Modificador;
                item.FechaModificacion = param.FechaModificacion;

                result.Add(item);

            }
            */

            return result;
            
        }

        public async Task<ArticuloDTO> ObtenerPorClave(int param)
        {
            var item = await _articuloRepository.ObtenerPorClave(param);

            var result = _mapper.Map<ArticuloDTO>(item);

            return result;
        }

        public async Task<ArticuloDTO> ObtenerPorGuid(string guid)
        {
            var item = await _articuloRepository.ObtenerPorGuid(guid);

            var result = _mapper.Map<ArticuloDTO>(item);

            return result;
        }
    }
}
