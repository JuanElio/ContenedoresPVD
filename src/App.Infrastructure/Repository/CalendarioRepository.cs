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
	public class CalendarioRepository : UtilRepository, ICalendarioRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly string _connectionString;
		private readonly ILogger<CalendarioRepository> _logger;

		public CalendarioRepository(ApplicationDbContext context, ILogger<CalendarioRepository> logger){
			_context = context;
			_logger = logger;
			_connectionString = _context.Database.GetConnectionString();
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Calendario table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task<int> Agregar(CalendarioDTO param)
		//{

		//	int id = 0;

		//	SqlParameter[] sqlparam = new SqlParameter[2];

		//	/*
		//	if (string.IsNullOrEmpty(param.SituacionRegistro))
		//		param.SituacionRegistro = "A";

		//	if (param.FechaCreacion == null)
		//		param.FechaCreacion = DateTime.Now;

		//	if( string.IsNullOrEmpty(param.GuidRegistro))
		//		param.GuidRegistro = System.Guid.NewGuid().ToString();
		//	*/

		//	sqlparam[0] = new SqlParameter("@EsFeriado",this.SetDb_NO_DEFINIDO(param.EsFeriado));
		//	sqlparam[1] = new SqlParameter("@EsFindeSemana",this.SetDb_NO_DEFINIDO(param.EsFindeSemana));

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_calendario_agregar";
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
		/// Saves a record to the Calendario table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(CalendarioActualizaDTO param)
		{

			/*if (param.FechaModificacion == null) param.FechaModificacion = DateTime.Now;*/

			SqlParameter[] sqlparam = new SqlParameter[2];

			sqlparam[0] = new SqlParameter("@Fecha", this.SetDbString(param.Fecha));
			sqlparam[1] = new SqlParameter("@EsFeriado", this.SetDbBoolean(param.EsFeriado));
			//sqlparam[2] = new SqlParameter("@EsFindeSemana", this.SetDbBoolean(param.EsFindeSemana));

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_calendario_actualizar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				await command.ExecuteNonQueryAsync();
			}
		}

		/// <summary>
		/// Delete a record to the Calendario table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{

		//	SqlParameter[] sqlparam = new SqlParameter[1];

		//	sqlparam[0] = new SqlParameter("@Fecha",param );

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_calendario_eliminar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();

		//	}
		//}

		/// <summary>
		/// Selects the Single object of Calendario table.
		/// </summary>
		public async Task<CalendarioDTO> ObtenerPorClave(string param)
		{
			CalendarioDTO registro = null;

			await using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				//Create the command and set its properties.
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_calendario_obtener";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@Fecha", param);

				//Open the connection and execute the reader.
				await connection.OpenAsync();

				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					if (reader.HasRows)
					{
						if (reader.Read())
						{
							registro = new CalendarioDTO();
							CreateMap(registro, reader);
						}
					}
					reader.Close();
				}
			}

			return registro;

		}

		/// <summary>
		/// Selects the Single object of Calendario table.
		/// </summary>
		//public async Task<CalendarioDTO> ObtenerPorGuid(string guid)
		//{
		//	CalendarioDTO registro = null;

		//	await using (SqlConnection connection = new SqlConnection(_connectionString))
		//	{
		//		//Create the command and set its properties.
		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_calendario_obtener_por_guid";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddWithValue("@GuidRegistro", guid);

		//		//Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		using (SqlDataReader reader = await command.ExecuteReaderAsync()) {
		//			if (reader.HasRows) {
		//				if (reader.Read()) {
		//					registro = new CalendarioDTO();
		//					CreateMap(registro, reader);
		//				}
		//			}
		//			reader.Close();
		//		}
		//	}

		//	return registro;

		//}

		/// <summary>
		/// Selects all records from the Calendario table.
		/// </summary>
		public async Task<List<CalendarioDTO>> ObtieneFechaFinal(string fechaInicio, int cantDias)
		{

			List<CalendarioDTO> lista = new List<CalendarioDTO>();

            SqlParameter[] sqlparam = new SqlParameter[2];

            sqlparam[0] = new SqlParameter("@FechaInicio", this.SetDbString(fechaInicio));
            sqlparam[1] = new SqlParameter("@Dias", this.SetDbInt(cantDias));

            await using (SqlConnection connection = new SqlConnection(_connectionString))
			{

				//Create the command and set its properties.
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_calendario_obtiene_fecha_fin";
				command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlparam);

                //Open the connection and execute the reader.
                await connection.OpenAsync();
				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {

					if (reader.HasRows) {

						while (reader.Read()) {

							CalendarioDTO registro = new CalendarioDTO();

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
		/// Set records from the Calendario table.
		/// </summary>
		public void CreateMap (CalendarioDTO registro, SqlDataReader reader)
		{
			registro.Fecha = (DateTime)this.GetDbDateTime(reader, "Fecha");
			registro.EsFeriado = false;// this.GetDbBoolean(reader, "EsFeriado");
			registro.EsFindeSemana = false; // this.GetDbBoolean(reader, "EsFindeSemana");
		}

		#endregion
	}
}
