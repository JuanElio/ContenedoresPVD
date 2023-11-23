using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.Application.Interfaces;
using App.Infrastructure.Interfaces;
using App.ModelDto.DTOs;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Services
{
	public class PersonaService : IPersonaService
	{
		private readonly IPersonaRepository _personaRepository;
		private readonly IMapper _mapper;

		public PersonaService(IPersonaRepository personaRepository, IMapper mapper ){
			_personaRepository = personaRepository;
			_mapper = mapper;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Persona table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(PersonaDTO param)
		{
			var item = _mapper.Map<Persona>(param);
			return await _personaRepository.Agregar(item);
		}

		/// <summary>
		/// Saves a record to the Persona table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(PersonaDTO param)
		{
			var item = _mapper.Map<Persona>(param);
			await _personaRepository.Actualizar(item);
		}

		/// <summary>
		/// Delete a record to the Persona table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	await _personaRepository.Eliminar(param);
		//}

		/// <summary>
		/// Selects the Single object of Persona table.
		/// </summary>
		//public async Task<PersonaDTO> ObtenerPorClave(string param)
		//{
		//	var item = await _personaRepository.ObtenerPorClave(param);
		//	var result = _mapper.Map<PersonaDTO>(item);
		//	return result;
		//}

		/// <summary>
		/// Selects the Single object of Persona table.
		/// </summary>
		//public async Task<PersonaDTO> ObtenerPorGuid(string guid)
		//{
		//	var item = await _personaRepository.ObtenerPorGuid(guid);
		//	var result = _mapper.Map<PersonaDTO>(item);
		//	return result;
		//}

		/// <summary>
		/// Selects the Single object of Persona table.
		/// </summary>
		public async Task<PersonaListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string codigoTipoIdentidad, string numeroDocumento)
		{
			var list = await _personaRepository.Listar( numeropagina,  cantfilas,  nombre,  codigoTipoIdentidad,  numeroDocumento);
			//var result = _mapper.Map<List<PersonaDTO>>(list);
			return list;
		}

		public async Task<PersonaDTO> ObtenerPorTipoNumero(string tipo, string numero)
        {
			var item = await _personaRepository.ObtenerPorTipoNumero(tipo, numero);
			var result = _mapper.Map<PersonaDTO>(item);
			return result;
		}
        //public Task<List<Persona>> ObtenerPorNombres(string nombre);
        public async Task<List<PersonaDTO>> ObtenerPorNombres(string nombre)
        {
            var list = await _personaRepository.ObtenerPorNombres( nombre);
            var result = _mapper.Map<List<PersonaDTO>>(list);
            return result;
        }
        #endregion
    }
}
