using App.Domain.Entities;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repository
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Methods

        /// <summary>
        /// Saves a record to the ARTICULO table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public async Task<int> Agregar(Articulo param)
        {
            _context.Articulo.Add(param);
            await _context.SaveChangesAsync();
            return param.IdArticulo;
        }

        /// <summary>
        /// Saves a record to the ARTICULO table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public async Task Actualizar(Articulo param)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(param).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Selects the Single object of ARTICULO table.
        /// </summary>
        public async Task<Articulo> ObtenerPorClave(int param)
        {
            return await _context.Articulo.Where(x => x.IdArticulo == param).FirstOrDefaultAsync();
        }

        public async Task<Articulo> ObtenerPorGuid(string guid)
        {
            return await _context.Articulo.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Selects all records from the ARTICULO table.
        /// </summary>
        public async Task<List<Articulo>> Listar()
        {
            return await _context.Articulo.ToListAsync();
        }

    }


    #endregion
}


