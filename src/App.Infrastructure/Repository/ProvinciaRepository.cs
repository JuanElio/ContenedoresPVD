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
	public class ProvinciaRepository : IProvinciaRepository
	{
		private readonly ApplicationDbContext _context;

		public ProvinciaRepository(ApplicationDbContext context){
			_context = context;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Provincia table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(Provincia param)
		{
			_context.Provincia.Add(param);
			await _context.SaveChangesAsync();
			return param.IdProvincia;
		}

		/// <summary>
		/// Saves a record to the Provincia table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(Provincia param)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Delete a record to the Provincia table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	var item = await _context.Provincia.Where(x => x.IdProvincia == param).FirstOrDefaultAsync();

		//	if (item != null)
		//	{
		//		_context.Proveedor.Remove(item);
		//		await _context.SaveChangesAsync();
		//	}
		//}

		/// <summary>
		/// Selects the Single object of Provincia table.
		/// </summary>
		public async Task<Provincia> ObtenerPorClave(int param)
		{
			return await _context.Provincia.Where(x => x.IdProvincia == param).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Selects the Single object of Provincia table.
		/// </summary>
		//public async Task<Provincia> ObtenerPorGuid(string guid)
		//{
		//	return await _context.Provincia.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
		//}

		/// <summary>
		/// Selects all records from the Provincia table.
		/// </summary>
		public async Task<List<Provincia>> Listar(string codigoDepartamento)
		{
			return await _context.Provincia.Where(x => x.CodigoProvinciaReniec.Substring(0,2) == codigoDepartamento).ToListAsync();
		}


		#endregion
	}
}
