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
	public class XXUnidadEjecutoraRepository : UtilRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly string _connectionString;
		private readonly ILogger<XXUnidadEjecutoraRepository> _logger;

		public XXUnidadEjecutoraRepository(ApplicationDbContext context, ILogger<XXUnidadEjecutoraRepository> logger){
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
		public async Task<int> Agregar(UnidadEjecutoraDTO param)
		{

			int id = 0;

			SqlParameter[] sqlparam = new SqlParameter[3];

			/*
			if (string.IsNullOrEmpty(param.SituacionRegistro))
				param.SituacionRegistro = "A";

			if (param.FechaCreacion == null)
				param.FechaCreacion = DateTime.Now;

			if( string.IsNullOrEmpty(param.GuidRegistro))
				param.GuidRegistro = System.Guid.NewGuid().ToString();
			*/

			sqlparam[0] = new SqlParameter("@CodigoUnidadEjecutora",this.SetDbString(param.CodigoUnidadEjecutora));
			sqlparam[1] = new SqlParameter("@Descripcion",this.SetDbString(param.Descripcion));
			sqlparam[2] = new SqlParameter("@UbigeoReniec",this.SetDbString(param.UbigeoReniec));

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_unidadejecutora_agregar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				/*await command.ExecuteNonQueryAsync();*/
				var retorno = await command.ExecuteScalarAsync();

				if (retorno != null) id = Convert.ToInt32(retorno);

			}

			return id;

		}

		/// <summary>
		/// Saves a record to the UnidadEjecutora table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(UnidadEjecutoraDTO param)
		{

			/*if (param.FechaModificacion == null) param.FechaModificacion = DateTime.Now;*/

			SqlParameter[] sqlparam = new SqlParameter[4];

			sqlparam[0] = new SqlParameter("@IdUnidadEjecutora",this.SetDbInt(param.IdUnidadEjecutora));
			sqlparam[1] = new SqlParameter("@CodigoUnidadEjecutora",this.SetDbString(param.CodigoUnidadEjecutora));
			sqlparam[2] = new SqlParameter("@Descripcion",this.SetDbString(param.Descripcion));
			sqlparam[3] = new SqlParameter("@UbigeoReniec",this.SetDbString(param.UbigeoReniec));

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_unidadejecutora_actualizar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				await command.ExecuteNonQueryAsync();
			}
		}

		/// <summary>
		/// Delete a record to the UnidadEjecutora table.
		/// </summary>
		public async Task Eliminar(int param)
		{

			SqlParameter[] sqlparam = new SqlParameter[1];

			sqlparam[0] = new SqlParameter("@IdUnidadEjecutora",param );

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_unidadejecutora_eliminar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				await command.ExecuteNonQueryAsync();

			}
		}

		/// <summary>
		/// Selects the Single object of UnidadEjecutora table.
		/// </summary>
		public async Task<UnidadEjecutoraDTO> ObtenerPorClave(int param)
		{
			UnidadEjecutoraDTO registro = null;

			await using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				//Create the command and set its properties.
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_unidadejecutora_obtener";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@IdUnidadEjecutora", param);

				//Open the connection and execute the reader.
				await connection.OpenAsync();

				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {
					if (reader.HasRows) {
						if (reader.Read()) {
							registro = new UnidadEjecutoraDTO();
							CreateMap(registro, reader);
						}
					}
					reader.Close();
				}
			}

			return registro;

		}

		/// <summary>
		/// Selects the Single object of UnidadEjecutora table.
		/// </summary>
		public async Task<UnidadEjecutoraDTO> ObtenerPorGuid(string guid)
		{
            UnidadEjecutoraDTO registro = null;

			await using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				//Create the command and set its properties.
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_unidadejecutora_obtener_por_guid";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@GuidRegistro", guid);

				//Open the connection and execute the reader.
				await connection.OpenAsync();

				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {
					if (reader.HasRows) {
						if (reader.Read()) {
							registro = new UnidadEjecutoraDTO();
							CreateMap(registro, reader);
						}
					}
					reader.Close();
				}
			}

			return registro;

		}

		/// <summary>
		/// Selects all records from the UnidadEjecutora table.
		/// </summary>
		public async Task<List<UnidadEjecutoraDTO>> Listar()
		{

			List<UnidadEjecutoraDTO> lista = new List<UnidadEjecutoraDTO>();

			await using (SqlConnection connection = new SqlConnection(_connectionString))
			{

				//Create the command and set its properties.
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_unidadejecutora_listar";
				command.CommandType = CommandType.StoredProcedure;

				//Open the connection and execute the reader.
				await connection.OpenAsync();
				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {

					if (reader.HasRows) {

						while (reader.Read()) {

							UnidadEjecutoraDTO registro = new UnidadEjecutoraDTO();

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
		/// Set records from the UnidadEjecutora table.
		/// </summary>
		public void CreateMap (UnidadEjecutoraDTO registro, SqlDataReader reader)
		{
			registro.IdUnidadEjecutora = this.GetDbInt(reader, "IdUnidadEjecutora");
			registro.CodigoUnidadEjecutora = this.GetDbString(reader, "CodigoUnidadEjecutora");
			registro.Descripcion = this.GetDbString(reader, "Descripcion");
			registro.UbigeoReniec = this.GetDbString(reader, "UbigeoReniec");
		}

		#endregion
	}
}
