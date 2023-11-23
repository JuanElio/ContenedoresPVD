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
	public class DistritoRepository : IDistritoRepository
	{
		private readonly ApplicationDbContext _context;

		public DistritoRepository(ApplicationDbContext context){
			_context = context;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Distrito table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(Distrito param)
		{
			_context.Distrito.Add(param);
			await _context.SaveChangesAsync();
			return param.IdDistrito;
		}

		/// <summary>
		/// Saves a record to the Distrito table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(Distrito param)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Delete a record to the Distrito table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	var item = await _context.Distrito.Where(x => x.IdDistrito == param).FirstOrDefaultAsync();

		//	if (item != null)
		//	{
		//		_context.Proveedor.Remove(item);
		//		await _context.SaveChangesAsync();
		//	}
		//}

		/// <summary>
		/// Selects the Single object of Distrito table.
		/// </summary>
		public async Task<Distrito> ObtenerPorClave(int param)
		{
			return await _context.Distrito.Where(x => x.IdDistrito == param).FirstOrDefaultAsync();
		}
      

        /// <summary>
        /// Selects the Single object of Distrito table.
        /// </summary>
        //public async Task<Distrito> ObtenerPorGuid(string guid)
        //{
        //	return await _context.Distrito.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
        //}

        /// <summary>
        /// Selects all records from the Distrito table.
        /// </summary>
        public async Task<List<Distrito>> Listar(string codigoProvinciaReniec, string codigoProvinciaInei)
		{
			return await _context.Distrito.Where(x => x.CodigoDistritoReniec.Substring(0, 4) == codigoProvinciaReniec || x.CodigoDistritoInei.Substring(0, 4) == codigoProvinciaInei).ToListAsync();
		}


		#endregion
	}
}
