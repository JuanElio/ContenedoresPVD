using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Persistence.Context;
using App.Domain.Entities;

namespace App.Infrastructure.Repository
{
	public class TipoPersonaRepository : ITipoPersonaRepository
	{
		private readonly ApplicationDbContext _context;

		public TipoPersonaRepository(ApplicationDbContext context){
			_context = context;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the TipoPersona table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<string> Agregar(TipoPersona param)
		{
			_context.TipoPersona.Add(param);
			await _context.SaveChangesAsync();
			return param.CodigoTipoPersona;
		}

		/// <summary>
		/// Saves a record to the TipoPersona table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(TipoPersona param)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Delete a record to the TipoPersona table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	var item = await _context.TipoPersona.Where(x => x.CodigoTipoPersona == param).FirstOrDefaultAsync();

		//	if (item != null)
		//	{
		//		_context.Proveedor.Remove(item);
		//		await _context.SaveChangesAsync();
		//	}
		//}

		/// <summary>
		/// Selects the Single object of TipoPersona table.
		/// </summary>
		public async Task<TipoPersona> ObtenerPorClave(string param)
		{
			return await _context.TipoPersona.Where(x => x.CodigoTipoPersona == param).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Selects the Single object of TipoPersona table.
		/// </summary>
		//public async Task<TipoPersona> ObtenerPorGuid(string guid)
		//{
		//	return await _context.TipoPersona.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
		//}

		/// <summary>
		/// Selects all records from the TipoPersona table.
		/// </summary>
		public async Task<List<TipoPersona>> Listar()
		{
			return await _context.TipoPersona.ToListAsync();
		}


		#endregion
	}
}
