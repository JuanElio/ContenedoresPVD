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
	public class TipoDocumentoIdentidadRepository : ITipoDocumentoIdentidadRepository
    {
		private readonly ApplicationDbContext _context;

		public TipoDocumentoIdentidadRepository(ApplicationDbContext context){
			_context = context;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the TipoDocumentoIdentidad table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<string> Agregar(TipoDocumentoIdentidad param)
		{
			_context.TipoDocumentoIdentidad.Add(param);
			await _context.SaveChangesAsync();
			return param.CodigoTipoIdentidad;
		}

		/// <summary>
		/// Saves a record to the TipoDocumentoIdentidad table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(TipoDocumentoIdentidad param)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Delete a record to the TipoDocumentoIdentidad table.
		/// </summary>
		//public async Task Eliminar(string param)
		//{
		//	var item = await _context.TipoDocumentoIdentidad.Where(x => x.CodigoTipoIdentidad == param).FirstOrDefaultAsync();

		//	if (item != null)
		//	{
		//		_context.Proveedor.Remove(item);
		//		await _context.SaveChangesAsync();
		//	}
		//}

		/// <summary>
		/// Selects the Single object of TipoDocumentoIdentidad table.
		/// </summary>
		public async Task<TipoDocumentoIdentidad> ObtenerPorClave(string param)
		{
			return await _context.TipoDocumentoIdentidad.Where(x => x.CodigoTipoIdentidad == param).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Selects the Single object of TipoDocumentoIdentidad table.
		/// </summary>
		//public async Task<TipoDocumentoIdentidad> ObtenerPorGuid(string guid)
		//{
		//	return await _context.TipoDocumentoIdentidad.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
		//}

		/// <summary>
		/// Selects all records from the TipoDocumentoIdentidad table.
		/// </summary>
		public async Task<List<TipoDocumentoIdentidad>> Listar()
		{
			return await _context.TipoDocumentoIdentidad.ToListAsync();
		}


		#endregion
	}
}
