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
using App.ModelDto.DTOs;

namespace App.Infrastructure.Repository
{
	public class PaisRepository : IPaisRepository
	{
		private readonly ApplicationDbContext _context;

		public PaisRepository(ApplicationDbContext context){
			_context = context;
		}

        #region Methods

        /// <summary>
        /// Saves a record to the Pais table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        //public async Task<int> Agregar(Pais param)
        //{
        //	_context.Pais.Add(param);
        //	await _context.SaveChangesAsync();
        //	return param.IdPais;
        //}

        /// <summary>
        /// Saves a record to the Pais table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        //public async Task Actualizar(Pais param)
        //{
        //	_context.ChangeTracker.Clear();
        //	_context.Entry(param).State = EntityState.Modified;
        //	await _context.SaveChangesAsync();
        //}

        /// <summary>
        /// Delete a record to the Pais table.
        /// </summary>
        //public async Task Eliminar(int param)
        //{
        //	var item = await _context.Pais.Where(x => x.IdPais == param).FirstOrDefaultAsync();

        //	if (item != null)
        //	{
        //		_context.Proveedor.Remove(item);
        //		await _context.SaveChangesAsync();
        //	}
        //}

        ///// <summary>
        ///// Selects the Single object of Pais table.
        ///// </summary>
        //public async Task<Pais> ObtenerPorClave(int param)
        //{
        //	return await _context.Pais.Where(x => x.IdPais == param).FirstOrDefaultAsync();
        //}

        ///// <summary>
        ///// Selects the Single object of Pais table.
        ///// </summary>
        //public async Task<Pais> ObtenerPorGuid(string guid)
        //{
        //	return await _context.Pais.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
        //}
        public async Task<Pais> ObtenerPorCodigo(string codigo)
        {
            return await _context.Pais.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Selects all records from the Pais table.
        /// </summary>
        public async Task<List<Pais>> Listar()
		{
			return await _context.Pais.ToListAsync();
		}


		#endregion
	}
}
