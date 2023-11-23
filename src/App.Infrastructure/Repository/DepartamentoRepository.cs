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
	public class DepartamentoRepository : IDepartamentoRepository
	{
		private readonly ApplicationDbContext _context;

		public DepartamentoRepository(ApplicationDbContext context){
			_context = context;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Departamento table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(Departamento param)
		{
			_context.Departamento.Add(param);
			await _context.SaveChangesAsync();
			return param.IdDepartamento;
		}

		/// <summary>
		/// Saves a record to the Departamento table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(Departamento param)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Delete a record to the Departamento table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	var item = await _context.Departamento.Where(x => x.IdDepartamento == param).FirstOrDefaultAsync();

		//	if (item != null)
		//	{
		//		_context.Proveedor.Remove(item);
		//		await _context.SaveChangesAsync();
		//	}
		//}

		/// <summary>
		/// Selects the Single object of Departamento table.
		/// </summary>
		public async Task<Departamento> ObtenerPorClave(int param)
		{
			return await _context.Departamento.Where(x => x.IdDepartamento == param).FirstOrDefaultAsync();
		}

        public async Task<Departamento> ObtenerPorCodigo(string reniec, string inei)
        {
            return await _context.Departamento.Where(x => x.CodigoDepartamentoInei == inei || x.CodigoDepartamentoReniec == reniec).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Selects the Single object of Departamento table.
        /// </summary>
        //public async Task<Departamento> ObtenerPorGuid(string guid)
        //{
        //	return await _context.Departamento.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
        //}

        /// <summary>
        /// Selects all records from the Departamento table.
        /// </summary>
        public async Task<List<Departamento>> Listar()
		{
			return await _context.Departamento.ToListAsync();
		}


		#endregion
	}
}
