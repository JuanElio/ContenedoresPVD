using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Persistence.Context;
using App.Infrastructure.Utils;
using App.ModelDto.DTOs;
using App.Domain.Entities;

namespace App.Infrastructure.Repository
{
	public class RedVialNacionalPuntoRepository : UtilRepository, IRedVialNacionalPuntoRepository
    {
        private readonly ApplicationDbContext _context;

        public RedVialNacionalPuntoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Methods

        /// <summary>
        /// Saves a record to the RedVialNacionalPunto table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public async Task<int> Agregar(RedVialNacionalPunto param)
        {
            _context.RedVialNacionalPunto.Add(param);
            await _context.SaveChangesAsync();
            return param.IdRedVialNacionalPunto;
        }

        /// <summary>
        /// Saves a record to the RedVialNacionalPunto table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public async Task Actualizar(RedVialNacionalPunto param)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(param).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a record to the RedVialNacionalPunto table.
        /// </summary>
        //public async Task Eliminar(int param)
        //{
        //    var item = await _context.RedVialNacionalPunto.Where(x => x. == param).FirstOrDefaultAsync();

        //    if (item != null)
        //    {
        //        _context.Proveedor.Remove(item);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        /// <summary>
        /// Selects all records from the RedVialNacionalPunto table.
        /// </summary>
        public async Task<List<RedVialNacionalPunto>> Listar()
        {
            return await _context.RedVialNacionalPunto.ToListAsync();
        }

        public async Task<List<RedVialNacionalPunto>> Listar(string ruta) { 
            return await _context.RedVialNacionalPunto.Where(x => x.Ruta == ruta ).OrderBy(x => x.Orden).ToListAsync();
        }


        #endregion
    }
}
