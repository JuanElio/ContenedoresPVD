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
using App.Infrastructure.Utils;

namespace App.Infrastructure.Repository
{
	public class UnidadEjecutoraRepository : UtilRepository, IUnidadEjecutoraRepository
	{
		private readonly ApplicationDbContext _context;
        private readonly string _connectionString;
        private readonly ILogger<CentroSaludRepository> _logger;

      

        public UnidadEjecutoraRepository(ApplicationDbContext context, ILogger<CentroSaludRepository> logger)
        {
			_context = context;
            _logger = logger;
            _connectionString = _context.Database.GetConnectionString();
        }

		#region Methods

		/// <summary>
		/// Saves a record to the UnidadEjecutora table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(UnidadEjecutora param)
		{
			_context.UnidadEjecutora.Add(param);
			await _context.SaveChangesAsync();
			return param.IdUnidadEjecutora;
		}

		/// <summary>
		/// Saves a record to the UnidadEjecutora table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(UnidadEjecutora param)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Delete a record to the UnidadEjecutora table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{
		//	var item = await _context.UnidadEjecutora.Where(x => x.IdUnidadEjecutora == param).FirstOrDefaultAsync();

		//	if (item != null)
		//	{
		//		_context.Proveedor.Remove(item);
		//		await _context.SaveChangesAsync();
		//	}
		//}

		/// <summary>
		/// Selects the Single object of UnidadEjecutora table.
		/// </summary>
		public async Task<UnidadEjecutora> ObtenerPorClave(int param)
		{
			return await _context.UnidadEjecutora.Where(x => x.IdUnidadEjecutora == param).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Selects the Single object of UnidadEjecutora table.
		/// </summary>
		//public async Task<UnidadEjecutora> ObtenerPorGuid(string guid)
		//{
		//	return await _context.UnidadEjecutora.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
		//}

		/// <summary>
		/// Selects all records from the UnidadEjecutora table.
		/// </summary>
		//public async Task<List<UnidadEjecutora>> Listar()
		//{
		//	return await _context.UnidadEjecutora.ToListAsync();
		//}
        public async Task<UnidadEjecutoraListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei)
        {

            List<UnidadEjecutoraDTO> lista = new List<UnidadEjecutoraDTO>();
            UnidadEjecutoraListaDTO unidadEjecutoraListaDTO = new UnidadEjecutoraListaDTO();

            SqlParameter[] sqlparam = new SqlParameter[7];

            sqlparam[0] = new SqlParameter("@numeropagina", this.SetDbInt(numeropagina));
            sqlparam[1] = new SqlParameter("@cantfilas", this.SetDbInt(cantfilas));
            sqlparam[2] = new SqlParameter("@nombre", this.SetDbString(nombre));
            sqlparam[3] = new SqlParameter("@ubigeoReniec", this.SetDbString(ubigeoReniec));
            sqlparam[4] = new SqlParameter("@ubigeoInei", this.SetDbString(ubigeoInei));
            sqlparam[5] = new SqlParameter("@piPagTotPag", SqlDbType.Int);
            sqlparam[5].Direction = ParameterDirection.Output;
            sqlparam[6] = new SqlParameter("@piPagTotReg", SqlDbType.Int);
            sqlparam[6].Direction = ParameterDirection.Output;

            await using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                //Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "app_unidadejecutora_listar";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlparam);

                //Open the connection and execute the reader.
                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {

                            UnidadEjecutoraDTO registro = new UnidadEjecutoraDTO();

                            CreateMap(registro, reader);

                            lista.Add(registro);
                        }
                    }
                    reader.Close();
                }
                unidadEjecutoraListaDTO.ListaUnidadEjecutoraDTO = lista;
                unidadEjecutoraListaDTO.TotalPaginas = (int)sqlparam[5].Value;
                unidadEjecutoraListaDTO.TotalRegistros = (int)sqlparam[6].Value;
            }
            return unidadEjecutoraListaDTO;

        }

        public void CreateMap(UnidadEjecutoraDTO registro, SqlDataReader reader)
        {
            registro.IdUnidadEjecutora = this.GetDbInt(reader, "IdUnidadEjecutora");
            registro.CodigoUnidadEjecutora = this.GetDbString(reader, "CodigoUnidadEjecutora");
            registro.Descripcion = this.GetDbString(reader, "Descripcion");
            registro.UbigeoReniec = this.GetDbString(reader, "UbigeoReniec");
            registro.UbigeoInei = this.GetDbString(reader, "UbigeoInei");
            //registro.totalPagina = this.GetDbInt(reader, "totalPagina");
        }

        #endregion
    }
}
