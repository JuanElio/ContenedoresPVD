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
	public class ProveedorRepository : IProveedorRepository
	{
		private readonly ApplicationDbContext _context;

		public ProveedorRepository(ApplicationDbContext context){
			_context = context;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the PROVEEDOR table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(Proveedor param)
		{

			_context.Proveedor.Add(param);
			await _context.SaveChangesAsync();
			return param.IdProveedor;

		}

		/// <summary>
		/// Saves a record to the PROVEEDOR table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(Proveedor param)
		{

			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();

		}

		/// <summary>
		/// Selects the Single object of PROVEEDOR table.
		/// </summary>
		public async Task<Proveedor> ObtenerPorClave(int param)
		{
			return await _context.Proveedor.Where(x => x.IdProveedor == param).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Selects the Single object of PROVEEDOR table.
		/// </summary>
		public async Task<Proveedor> ObtenerPorGuid(string guid)
		{
			return await _context.Proveedor.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Selects all records from the PROVEEDOR table.
		/// </summary>
		public async Task<List<Proveedor>> Listar()
		{
			return await _context.Proveedor.ToListAsync();
		}

        public async Task Eliminar(int param)
        {
            var item = await _context.Proveedor.Where(x => x.IdProveedor == param).FirstOrDefaultAsync();

			if (item != null)
			{
				_context.Proveedor.Remove(item);
                await _context.SaveChangesAsync();
            }

        }


        #endregion
    }
}
