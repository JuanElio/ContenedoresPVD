using App.Domain.Entities;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace App.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
	{
		private readonly ApplicationDbContext _context;

		public ClienteRepository(ApplicationDbContext context){
			_context = context;
		}

		#region Methods

		/// <summary>
		/// Saves a record to the CLIENTE table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(Cliente param)
		{
			_context.Cliente.Add(param);
			await _context.SaveChangesAsync();
			return param.IdCliente;
		}

		/// <summary>
		/// Saves a record to the CLIENTE table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(Cliente param)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Selects the Single object of CLIENTE table.
		/// </summary>
		public async Task<Cliente> ObtenerPorClave(int param)
		{
			return await _context.Cliente.Where(x => x.IdCliente == param).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Selects the Single object of CLIENTE table.
		/// </summary>
		public async Task<Cliente> ObtenerPorGuid(string guid)
		{
			return await _context.Cliente.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Selects all records from the CLIENTE table.
		/// </summary>
		public async Task<List<Cliente>> Listar()
		{
			return await _context.Cliente.ToListAsync();
		}

		#endregion
	}
}
