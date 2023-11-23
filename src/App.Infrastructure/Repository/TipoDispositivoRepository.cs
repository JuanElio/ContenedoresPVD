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

namespace App.Infrastructure.Repository
{
	public class TipoDispositivoRepository : UtilRepository, ITipoDispositivoRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly string _connectionString;
		private readonly ILogger<TipoDispositivoRepository> _logger;

		public TipoDispositivoRepository(ApplicationDbContext context, ILogger<TipoDispositivoRepository> logger){
			_context = context;
			_logger = logger;
			_connectionString = _context.Database.GetConnectionString();
		}

		#region Methods

		/// <summary>
		/// Saves a record to the TipoDispositivo table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task<int> Agregar(TipodispositivoDTO param)
		//{

		//	int id = 0;

		//	SqlParameter[] sqlparam = new SqlParameter[3];

		//	/*
		//	if (string.IsNullOrEmpty(param.SituacionRegistro))
		//		param.SituacionRegistro = "A";

		//	if (param.FechaCreacion == null)
		//		param.FechaCreacion = DateTime.Now;

		//	if( string.IsNullOrEmpty(param.GuidRegistro))
		//		param.GuidRegistro = System.Guid.NewGuid().ToString();
		//	*/

		//	sqlparam[0] = new SqlParameter("@CodigoTipoDispositivo",this.SetDb_NO_DEFINIDO(param.CodigoTipoDispositivo));
		//	sqlparam[1] = new SqlParameter("@DescripcionTipoDispositivo",this.SetDbString(param.DescripcionTipoDispositivo));
		//	sqlparam[2] = new SqlParameter("@Estado",this.SetDbString(param.Estado));

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_tipodispositivo_agregar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		/*await command.ExecuteNonQueryAsync();*/
		//		var retorno = await command.ExecuteScalarAsync();

		//		if (retorno != null) id = Convert.ToInt32(retorno);

		//	}

		//	return id;

		//}

		/// <summary>
		/// Saves a record to the TipoDispositivo table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task Actualizar(TipodispositivoDTO param)
		//{

		//	/*if (param.FechaModificacion == null) param.FechaModificacion = DateTime.Now;*/

		//	SqlParameter[] sqlparam = new SqlParameter[3];

		//	sqlparam[0] = new SqlParameter("@CodigoTipoDispositivo",this.SetDb_NO_DEFINIDO(param.CodigoTipoDispositivo));
		//	sqlparam[1] = new SqlParameter("@DescripcionTipoDispositivo",this.SetDbString(param.DescripcionTipoDispositivo));
		//	sqlparam[2] = new SqlParameter("@Estado",this.SetDbString(param.Estado));

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_tipodispositivo_actualizar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();
		//	}
		//}

		/// <summary>
		/// Delete a record to the TipoDispositivo table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{

		//	SqlParameter[] sqlparam = new SqlParameter[1];

		//	sqlparam[0] = new SqlParameter("@",param );

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_tipodispositivo_eliminar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();

		//	}
		//}

		/// <summary>
		/// Selects all records from the TipoDispositivo table.
		/// </summary>
		public async Task<List<TipoDispositivoDTO>> Listar()
		{

			List<TipoDispositivoDTO> lista = new List<TipoDispositivoDTO>();

			await using (SqlConnection connection = new SqlConnection(_connectionString))
			{

				//Create the command and set its properties.
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_tipodispositivo_listar";
				command.CommandType = CommandType.StoredProcedure;

				//Open the connection and execute the reader.
				await connection.OpenAsync();
				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {

					if (reader.HasRows) {

						while (reader.Read()) {

                            TipoDispositivoDTO registro = new TipoDispositivoDTO();

							CreateMap(registro, reader);

							lista.Add(registro);
						}
					}
					reader.Close();
				}
			}
			return lista;

		}
		/// <summary>
		/// Set records from the TipoDispositivo table.
		/// </summary>
		public void CreateMap (TipoDispositivoDTO registro, SqlDataReader reader)
		{
			registro.CodigoTipoDispositivo = this.GetDbString(reader, "CodigoTipoDispositivo");
			registro.DescripcionTipoDispositivo = this.GetDbString(reader, "DescripcionTipoDispositivo");
			registro.Estado = this.GetDbString(reader, "Estado");
		}

		#endregion
	}
}
