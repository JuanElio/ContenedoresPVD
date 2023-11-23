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
	public class DispositivoLegalRepository : UtilRepository, IDispositivoLegalRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly string _connectionString;
		private readonly ILogger<DispositivoLegalRepository> _logger;

		public DispositivoLegalRepository(ApplicationDbContext context, ILogger<DispositivoLegalRepository> logger){
			_context = context;
			_logger = logger;
			_connectionString = _context.Database.GetConnectionString();
		}

		#region Methods

		/// <summary>
		/// Saves a record to the DispositivoLegal table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(DispositivoLegalAgregarDTO param)
		{

			int id = 0;

			SqlParameter[] sqlparam = new SqlParameter[5];

			/*
			if (string.IsNullOrEmpty(param.SituacionRegistro))
				param.SituacionRegistro = "A";

			if (param.FechaCreacion == null)
				param.FechaCreacion = DateTime.Now;

			if( string.IsNullOrEmpty(param.GuidRegistro))
				param.GuidRegistro = System.Guid.NewGuid().ToString();
			*/

			sqlparam[0] = new SqlParameter("@CodigoTipoDispositivo", this.SetDbString(param.CodigoTipoDispositivo));
            sqlparam[1] = new SqlParameter("@Nombre", this.SetDbString(param.Nombre));
            sqlparam[2] = new SqlParameter("@FechaPublicacion", this.SetDbDateTime(param.FechaPublicacion));
			sqlparam[3] = new SqlParameter("@IdDispositivoLegalPadre", this.SetDbInt(param.IdDispositivoLegalPadre));
            sqlparam[4] = new SqlParameter("@IdDispositivoLegal", SqlDbType.Int);
            sqlparam[4].Direction = ParameterDirection.Output;

            await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_dispositivolegal_agregar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				/*await command.ExecuteNonQueryAsync();*/
				var retorno = await command.ExecuteScalarAsync();

				if (retorno != null) id = (int)sqlparam[4].Value;

            }

			return id;

		}

		/// <summary>
		/// Saves a record to the DispositivoLegal table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task Actualizar(DispositivolegalDTO param)
		//{

		//	/*if (param.FechaModificacion == null) param.FechaModificacion = DateTime.Now;*/

		//	SqlParameter[] sqlparam = new SqlParameter[5];

		//	sqlparam[0] = new SqlParameter("@IdDispositivoLegal",this.SetDbInt(param.IdDispositivoLegal));
		//	sqlparam[1] = new SqlParameter("@CodigoTipoDispositivo",this.SetDb_NO_DEFINIDO(param.CodigoTipoDispositivo));
		//	sqlparam[2] = new SqlParameter("@Nombre",this.SetDbString(param.Nombre));
		//	sqlparam[3] = new SqlParameter("@FechaPublicacion",this.SetDb_NO_DEFINIDO(param.FechaPublicacion));
		//	sqlparam[4] = new SqlParameter("@IdDispositivoLegalPadre",this.SetDbInt(param.IdDispositivoLegalPadre));

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_dispositivolegal_actualizar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();
		//	}
		//}

		/// <summary>
		/// Delete a record to the DispositivoLegal table.
		/// </summary>
		public async Task Eliminar(int param)
		{

			SqlParameter[] sqlparam = new SqlParameter[1];

			sqlparam[0] = new SqlParameter("@IdDispositivoLegal", param);

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_dispositivolegal_eliminar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				await command.ExecuteNonQueryAsync();

			}
		}

        /// <summary>
        /// Selects the Single object of DispositivoLegal table.
        /// </summary>
        //
        public async Task<DispositivoLegal> ObtenerPorClave(int param)
        {
            return await _context.DispositivoLegal.Where(x => x.IdDispositivoLegal == param).FirstOrDefaultAsync();
        }
        //public async Task<DispositivolegalDTO> ObtenerPorClave(string param)
        //{
        //	DispositivolegalDTO registro = null;

        //	await using (SqlConnection connection = new SqlConnection(_connectionString))
        //	{
        //		//Create the command and set its properties.
        //		SqlCommand command = new SqlCommand();
        //		command.Connection = connection;
        //		command.CommandText = "app_dispositivolegal_obtener";
        //		command.CommandType = CommandType.StoredProcedure;
        //		command.Parameters.AddWithValue("@CodigoTipoDispositivo", param);

        //		//Open the connection and execute the reader.
        //		await connection.OpenAsync();

        //		using (SqlDataReader reader = await command.ExecuteReaderAsync()) {
        //			if (reader.HasRows) {
        //				if (reader.Read()) {
        //					registro = new DispositivolegalDTO();
        //					CreateMap(registro, reader);
        //				}
        //			}
        //			reader.Close();
        //		}
        //	}

        //	return registro;

        //}

        /// <summary>
        /// Selects the Single object of DispositivoLegal table.
        /// </summary>
        //public async Task<DispositivolegalDTO> ObtenerPorGuid(string guid)
        //{
        //	DispositivolegalDTO registro = null;

        //	await using (SqlConnection connection = new SqlConnection(_connectionString))
        //	{
        //		//Create the command and set its properties.
        //		SqlCommand command = new SqlCommand();
        //		command.Connection = connection;
        //		command.CommandText = "app_dispositivolegal_obtener_por_guid";
        //		command.CommandType = CommandType.StoredProcedure;
        //		command.Parameters.AddWithValue("@GuidRegistro", guid);

        //		//Open the connection and execute the reader.
        //		await connection.OpenAsync();

        //		using (SqlDataReader reader = await command.ExecuteReaderAsync()) {
        //			if (reader.HasRows) {
        //				if (reader.Read()) {
        //					registro = new DispositivolegalDTO();
        //					CreateMap(registro, reader);
        //				}
        //			}
        //			reader.Close();
        //		}
        //	}

        //	return registro;

        //}

        /// <summary>
        /// Selects all records from the DispositivoLegal table.
        /// </summary>
        public async Task<List<DispositivoLegalDTO>> Listar()
		{

			List<DispositivoLegalDTO> lista = new List<DispositivoLegalDTO>();

			await using (SqlConnection connection = new SqlConnection(_connectionString))
			{

				//Create the command and set its properties.
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_dispositivolegal_listar";
				command.CommandType = CommandType.StoredProcedure;

				//Open the connection and execute the reader.
				await connection.OpenAsync();
				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {

					if (reader.HasRows) {

						while (reader.Read()) {

							DispositivoLegalDTO registro = new DispositivoLegalDTO();

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
		/// Set records from the DispositivoLegal table.
		/// </summary>
		public void CreateMap (DispositivoLegalDTO registro, SqlDataReader reader)
		{
			registro.IdDispositivoLegal = this.GetDbInt(reader, "IdDispositivoLegal");
			registro.CodigoTipoDispositivo = this.GetDbString(reader, "CodigoTipoDispositivo");
			registro.Nombre = this.GetDbString(reader, "Nombre");
			//registro.FechaPublicacionString = this.GetDbString(reader, "FechaPublicacionString");
            registro.FechaPublicacion = this.GetDbDateTime(reader, "FechaPublicacion");
            registro.IdDispositivoLegalPadre = this.GetDbInt(reader, "IdDispositivoLegalPadre");
            registro.DispositivoPadre = this.GetDbString(reader, "DispositivoPadre");
            registro.DescripcionTipoDispositivo = this.GetDbString(reader, "DescripcionTipoDispositivo");
            

        }

		#endregion
	}
}
