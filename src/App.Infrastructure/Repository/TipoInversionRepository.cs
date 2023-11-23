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
	public class TipoInversionRepository : ITipoInversionRepository
	{
		private readonly ApplicationDbContext _context;

		public TipoInversionRepository(ApplicationDbContext context){
			_context = context;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the TipoInversion table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task<int> Agregar(Tipoinversion param)
		//{
		//	_context.Tipoinversion.Add(param);
		//	await _context.SaveChangesAsync();
		//	return param.CodigoInversion;
		//}

		/// <summary>
		/// Saves a record to the TipoInversion table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task Actualizar(Tipoinversion param)
		//{
		//	_context.ChangeTracker.Clear();
		//	_context.Entry(param).State = EntityState.Modified;
		//	await _context.SaveChangesAsync();
		//}

		/// <summary>
		/// Delete a record to the TipoInversion table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	var item = await _context.Tipoinversion.Where(x => x.CodigoInversion == param).FirstOrDefaultAsync();

		//	if (item != null)
		//	{
		//		_context.Proveedor.Remove(item);
		//		await _context.SaveChangesAsync();
		//	}
		//}

		/// <summary>
		/// Selects the Single object of TipoInversion table.
		/// </summary>
		//public async Task<Tipoinversion> ObtenerPorClave(string param)
		//{
		//	return await _context.Tipoinversion.Where(x => x.CodigoInversion == param).FirstOrDefaultAsync();
		//}

		///// <summary>
		///// Selects the Single object of TipoInversion table.
		///// </summary>
		//public async Task<Tipoinversion> ObtenerPorGuid(string guid)
		//{
		//	return await _context.Tipoinversion.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
		//}

		/// <summary>
		/// Selects all records from the TipoInversion table.
		/// </summary>
		public async Task<List<TipoInversion>> Listar()
		{
			return await _context.TipoInversion.ToListAsync();
		}


		#endregion
	}
}
