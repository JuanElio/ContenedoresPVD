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
	public class TipoDocumentalRepository : UtilRepository, ITipoDocumentalRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly string _connectionString;
		private readonly ILogger<TipoDocumentalRepository> _logger;

		public TipoDocumentalRepository(ApplicationDbContext context, ILogger<TipoDocumentalRepository> logger){
			_context = context;
			_logger = logger;
			_connectionString = _context.Database.GetConnectionString();
		}

		#region Methods

		/// <summary>
		/// Saves a record to the TipoDocumental table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(TipoDocumentalDTO param)
		{

			int id = 0;

			SqlParameter[] sqlparam = new SqlParameter[14];

			/*
			if (string.IsNullOrEmpty(param.SituacionRegistro))
				param.SituacionRegistro = "A";

			if (param.FechaCreacion == null)
				param.FechaCreacion = DateTime.Now;

			if( string.IsNullOrEmpty(param.GuidRegistro))
				param.GuidRegistro = System.Guid.NewGuid().ToString();
			*/

			sqlparam[0] = new SqlParameter("@Descripcion", this.SetDbString(param.Descripcion));
			sqlparam[1] = new SqlParameter("@Sigla", this.SetDbString(param.Sigla));
			sqlparam[2] = new SqlParameter("@FlagEntrada", this.SetDbInt(param.FlagEntrada));
			sqlparam[3] = new SqlParameter("@FlagInterno", this.SetDbInt(param.FlagInterno));
			sqlparam[4] = new SqlParameter("@FlagSalida", this.SetDbInt(param.FlagSalida));
			sqlparam[5] = new SqlParameter("@DocEsp", this.SetDbInt(param.DocEsp));
			sqlparam[6] = new SqlParameter("@FlagWeb", this.SetDbInt(param.FlagWeb));
			sqlparam[7] = new SqlParameter("@Anexo", this.SetDbString(param.Anexo));
			sqlparam[8] = new SqlParameter("@CodigoPide", this.SetDbString(param.CodigoPide));
			sqlparam[9] = new SqlParameter("@FlagSalidaGeneral", this.SetDbBoolean(param.FlagSalidaGeneral));
			sqlparam[10] = new SqlParameter("@FlagInternoAPersonal", this.SetDbBoolean(param.FlagInternoAPersonal));
			sqlparam[11] = new SqlParameter("@FlagPersonalGeneral", this.SetDbBoolean(param.FlagPersonalGeneral));
			sqlparam[12] = new SqlParameter("@FlagPersonal", this.SetDbBoolean(param.FlagPersonal));
            sqlparam[13] = new SqlParameter("@IdTipoDocumental", SqlDbType.Int);
            sqlparam[13].Direction = ParameterDirection.Output;


            await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_tipodocumental_agregar";
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
		/// Saves a record to the TipoDocumental table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task Actualizar(TipodocumentalDTO param)
		//{

		//	/*if (param.FechaModificacion == null) param.FechaModificacion = DateTime.Now;*/

		//	SqlParameter[] sqlparam = new SqlParameter[15];

		//	sqlparam[0] = new SqlParameter("@IdTipoDocumental",this.SetDbInt(param.IdTipoDocumental));
		//	sqlparam[1] = new SqlParameter("@Descripcion",this.SetDbString(param.Descripcion));
		//	sqlparam[2] = new SqlParameter("@Sigla",this.SetDb_NO_DEFINIDO(param.Sigla));
		//	sqlparam[3] = new SqlParameter("@FlagEntrada",this.SetDbInt(param.FlagEntrada));
		//	sqlparam[4] = new SqlParameter("@FlagInterno",this.SetDbInt(param.FlagInterno));
		//	sqlparam[5] = new SqlParameter("@FlagSalida",this.SetDbInt(param.FlagSalida));
		//	sqlparam[6] = new SqlParameter("@DocEsp",this.SetDbInt(param.DocEsp));
		//	sqlparam[7] = new SqlParameter("@FlagWeb",this.SetDbInt(param.FlagWeb));
		//	sqlparam[8] = new SqlParameter("@Anexo",this.SetDb_NO_DEFINIDO(param.Anexo));
		//	sqlparam[9] = new SqlParameter("@CodigoPide",this.SetDb_NO_DEFINIDO(param.CodigoPide));
		//	sqlparam[10] = new SqlParameter("@FlagSalidaGeneral",this.SetDb_NO_DEFINIDO(param.FlagSalidaGeneral));
		//	sqlparam[11] = new SqlParameter("@FlagInternoAPersonal",this.SetDb_NO_DEFINIDO(param.FlagInternoAPersonal));
		//	sqlparam[12] = new SqlParameter("@FlagPersonalGeneral",this.SetDb_NO_DEFINIDO(param.FlagPersonalGeneral));
		//	sqlparam[13] = new SqlParameter("@FlagPersonal",this.SetDb_NO_DEFINIDO(param.FlagPersonal));
		//	sqlparam[14] = new SqlParameter("@FlagEstado",this.SetDb_NO_DEFINIDO(param.FlagEstado));

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_tipodocumental_actualizar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();
		//	}
		//}

		/// <summary>
		/// Delete a record to the TipoDocumental table.
		/// </summary>
		//public async Task Eliminar(int param)
		//{

		//	SqlParameter[] sqlparam = new SqlParameter[1];

		//	sqlparam[0] = new SqlParameter("@IdTipoDocumental",param );

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_tipodocumental_eliminar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();

		//	}
		//}

		/// <summary>
		/// Selects the Single object of TipoDocumental table.
		/// </summary>
		//public async Task<TipodocumentalDTO> ObtenerPorClave(int param)
		//{
		//	TipodocumentalDTO registro = null;

		//	await using (SqlConnection connection = new SqlConnection(_connectionString))
		//	{
		//		//Create the command and set its properties.
		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_tipodocumental_obtener";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddWithValue("@IdTipoDocumental", param);

		//		//Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		using (SqlDataReader reader = await command.ExecuteReaderAsync()) {
		//			if (reader.HasRows) {
		//				if (reader.Read()) {
		//					registro = new TipodocumentalDTO();
		//					CreateMap(registro, reader);
		//				}
		//			}
		//			reader.Close();
		//		}
		//	}

		//	return registro;

		//}

		/// <summary>
		/// Selects the Single object of TipoDocumental table.
		/// </summary>
		//public async Task<TipodocumentalDTO> ObtenerPorGuid(string guid)
		//{
		//	TipodocumentalDTO registro = null;

		//	await using (SqlConnection connection = new SqlConnection(_connectionString))
		//	{
		//		//Create the command and set its properties.
		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_tipodocumental_obtener_por_guid";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddWithValue("@GuidRegistro", guid);

		//		//Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		using (SqlDataReader reader = await command.ExecuteReaderAsync()) {
		//			if (reader.HasRows) {
		//				if (reader.Read()) {
		//					registro = new TipodocumentalDTO();
		//					CreateMap(registro, reader);
		//				}
		//			}
		//			reader.Close();
		//		}
		//	}

		//	return registro;

		//}

		/// <summary>
		/// Selects all records from the TipoDocumental table.
		/// </summary>
		public async Task<List<TipoDocumentalDTO>> Listar()
		{

			List<TipoDocumentalDTO> lista = new List<TipoDocumentalDTO>();

			await using (SqlConnection connection = new SqlConnection(_connectionString))
			{

				//Create the command and set its properties.
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_tipodocumental_listar";
				command.CommandType = CommandType.StoredProcedure;

				//Open the connection and execute the reader.
				await connection.OpenAsync();
				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {

					if (reader.HasRows) {

						while (reader.Read()) {

							TipoDocumentalDTO registro = new TipoDocumentalDTO();

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
		/// Set records from the TipoDocumental table.
		/// </summary>
		public void CreateMap (TipoDocumentalDTO registro, SqlDataReader reader)
		{
			registro.IdTipoDocumental = this.GetDbInt(reader, "IdTipoDocumental");
			registro.Descripcion = this.GetDbString(reader, "Descripcion");
			registro.Sigla = this.GetDbString(reader, "Sigla");
			registro.FlagEntrada = this.GetDbInt(reader, "FlagEntrada");
			registro.FlagInterno = this.GetDbInt(reader, "FlagInterno");
			registro.FlagSalida = this.GetDbInt(reader, "FlagSalida");
			registro.DocEsp = this.GetDbInt(reader, "DocEsp");
			registro.FlagWeb = this.GetDbInt(reader, "FlagWeb");
			registro.Anexo = this.GetDbString(reader, "Anexo");
			registro.CodigoPide = this.GetDbString(reader, "CodigoPide");
			registro.FlagSalidaGeneral = this.GetDbBoolean(reader, "FlagSalidaGeneral");
			registro.FlagInternoAPersonal = this.GetDbBoolean(reader, "FlagInternoAPersonal");
			registro.FlagPersonalGeneral = this.GetDbBoolean(reader, "FlagPersonalGeneral");
			registro.FlagPersonal = this.GetDbBoolean(reader, "FlagPersonal");
			registro.Estado = this.GetDbString(reader, "Estado");
		}

		#endregion
	}
}
