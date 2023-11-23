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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Infrastructure.Repository
{
	public class ColegioRepository : UtilRepository, IColegioRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly string _connectionString;
		private readonly ILogger<ColegioRepository> _logger;

		public ColegioRepository(ApplicationDbContext context, ILogger<ColegioRepository> logger){
			_context = context;
			_logger = logger;
			_connectionString = _context.Database.GetConnectionString();
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Colegio table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task<int> Agregar(ColegioDTO param)
		//{

		//	int id = 0;

		//	SqlParameter[] sqlparam = new SqlParameter[19];

		//	/*
		//	if (string.IsNullOrEmpty(param.SituacionRegistro))
		//		param.SituacionRegistro = "A";

		//	if (param.FechaCreacion == null)
		//		param.FechaCreacion = DateTime.Now;

		//	if( string.IsNullOrEmpty(param.GuidRegistro))
		//		param.GuidRegistro = System.Guid.NewGuid().ToString();
		//	*/

		//	sqlparam[0] = new SqlParameter("@IdColegio",this.SetDbInt(param.IdColegio));
		//	sqlparam[1] = new SqlParameter("@CodigoLocal",this.SetDbString(param.CodigoLocal));
		//	sqlparam[2] = new SqlParameter("@CodigoModulo",this.SetDbString(param.CodigoModulo));
		//	sqlparam[3] = new SqlParameter("@NombreColegio",this.SetDbString(param.NombreColegio));
		//	sqlparam[4] = new SqlParameter("@Nivel",this.SetDbString(param.Nivel));
		//	sqlparam[5] = new SqlParameter("@Forma",this.SetDbString(param.Forma));
		//	sqlparam[6] = new SqlParameter("@TipoSexo",this.SetDbString(param.TipoSexo));
		//	sqlparam[7] = new SqlParameter("@Gestion",this.SetDbString(param.Gestion));
		//	sqlparam[8] = new SqlParameter("@Director",this.SetDb_NO_DEFINIDO(param.Director));
		//	sqlparam[9] = new SqlParameter("@Ugel",this.SetDbString(param.Ugel));
		//	sqlparam[10] = new SqlParameter("@Direccion",this.SetDb_NO_DEFINIDO(param.Direccion));
		//	sqlparam[11] = new SqlParameter("@Longitud",this.SetDb_NO_DEFINIDO(param.Longitud));
		//	sqlparam[12] = new SqlParameter("@Latitud",this.SetDb_NO_DEFINIDO(param.Latitud));
		//	sqlparam[13] = new SqlParameter("@Estado",this.SetDbString(param.Estado));
		//	sqlparam[14] = new SqlParameter("@AlumnoHombres",this.SetDbInt(param.AlumnoHombres));
		//	sqlparam[15] = new SqlParameter("@AlumnoMujeres",this.SetDbInt(param.AlumnoMujeres));
		//	sqlparam[16] = new SqlParameter("@Docentes",this.SetDbInt(param.Docentes));
		//	sqlparam[17] = new SqlParameter("@UbigeoInei",this.SetDb_NO_DEFINIDO(param.UbigeoInei));
		//	sqlparam[18] = new SqlParameter("@UbigeoReniec",this.SetDb_NO_DEFINIDO(param.UbigeoReniec));

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_colegio_agregar";
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

		///// <summary>
		///// Saves a record to the Colegio table.
		///// returns True if value saved successfullyelse false
		///// Throw exception with message value 'EXISTS' if the data is duplicate
		///// </summary>
		//public async Task Actualizar(ColegioDTO param)
		//{

		//	/*if (param.FechaModificacion == null) param.FechaModificacion = DateTime.Now;*/

		//	SqlParameter[] sqlparam = new SqlParameter[19];

		//	sqlparam[0] = new SqlParameter("@IdColegio",this.SetDbInt(param.IdColegio));
		//	sqlparam[1] = new SqlParameter("@CodigoLocal",this.SetDbString(param.CodigoLocal));
		//	sqlparam[2] = new SqlParameter("@CodigoModulo",this.SetDbString(param.CodigoModulo));
		//	sqlparam[3] = new SqlParameter("@NombreColegio",this.SetDbString(param.NombreColegio));
		//	sqlparam[4] = new SqlParameter("@Nivel",this.SetDbString(param.Nivel));
		//	sqlparam[5] = new SqlParameter("@Forma",this.SetDbString(param.Forma));
		//	sqlparam[6] = new SqlParameter("@TipoSexo",this.SetDbString(param.TipoSexo));
		//	sqlparam[7] = new SqlParameter("@Gestion",this.SetDbString(param.Gestion));
		//	sqlparam[8] = new SqlParameter("@Director",this.SetDb_NO_DEFINIDO(param.Director));
		//	sqlparam[9] = new SqlParameter("@Ugel",this.SetDbString(param.Ugel));
		//	sqlparam[10] = new SqlParameter("@Direccion",this.SetDb_NO_DEFINIDO(param.Direccion));
		//	sqlparam[11] = new SqlParameter("@Longitud",this.SetDb_NO_DEFINIDO(param.Longitud));
		//	sqlparam[12] = new SqlParameter("@Latitud",this.SetDb_NO_DEFINIDO(param.Latitud));
		//	sqlparam[13] = new SqlParameter("@Estado",this.SetDbString(param.Estado));
		//	sqlparam[14] = new SqlParameter("@AlumnoHombres",this.SetDbInt(param.AlumnoHombres));
		//	sqlparam[15] = new SqlParameter("@AlumnoMujeres",this.SetDbInt(param.AlumnoMujeres));
		//	sqlparam[16] = new SqlParameter("@Docentes",this.SetDbInt(param.Docentes));
		//	sqlparam[17] = new SqlParameter("@UbigeoInei",this.SetDb_NO_DEFINIDO(param.UbigeoInei));
		//	sqlparam[18] = new SqlParameter("@UbigeoReniec",this.SetDb_NO_DEFINIDO(param.UbigeoReniec));

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_colegio_actualizar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();
		//	}
		//}

		///// <summary>
		///// Delete a record to the Colegio table.
		///// </summary>
		//public async Task Eliminar(int param)
		//{

		//	SqlParameter[] sqlparam = new SqlParameter[1];

		//	sqlparam[0] = new SqlParameter("@",param );

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_colegio_eliminar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();

		//	}
		//}

		/// <summary>
		/// Selects all records from the Colegio table.
		/// </summary>
		public async Task<ColegioListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei)
		{

			List<ColegioDTO> lista = new List<ColegioDTO>();
            ColegioListaDTO colegioListaDTO = new ColegioListaDTO();

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
				command.CommandText = "app_colegio_listar";
				command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlparam);

                //Open the connection and execute the reader.
                await connection.OpenAsync();
				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {

					if (reader.HasRows) {

						while (reader.Read()) {

							ColegioDTO registro = new ColegioDTO();

							CreateMap(registro, reader);

							lista.Add(registro);
						}
					}
					reader.Close();
				}
                colegioListaDTO.ListaColegioDTO = lista;
                colegioListaDTO.TotalPaginas = (int)sqlparam[5].Value;
                colegioListaDTO.TotalRegistros = (int)sqlparam[6].Value;
            }
			return colegioListaDTO;

		}
		/// <summary>
		/// Set records from the Colegio table.
		/// </summary>
		public void CreateMap (ColegioDTO registro, SqlDataReader reader)
		{
			registro.IdColegio = this.GetDbInt(reader, "IdColegio");
			registro.CodigoLocal = this.GetDbString(reader, "CodigoLocal");
			registro.CodigoModulo = this.GetDbString(reader, "CodigoModulo");
			registro.NombreColegio = this.GetDbString(reader, "NombreColegio");
			registro.Nivel = this.GetDbString(reader, "Nivel");
			registro.Forma = this.GetDbString(reader, "Forma");
			registro.TipoSexo = this.GetDbString(reader, "TipoSexo");
			registro.Gestion = this.GetDbString(reader, "Gestion");
			registro.Director = this.GetDbString(reader, "Director");
			registro.Ugel = this.GetDbString(reader, "Ugel");
			registro.Direccion = this.GetDbString(reader, "Direccion");
			registro.Longitud = this.GetDbFloat(reader, "Longitud");
			registro.Latitud = this.GetDbFloat(reader, "Latitud");
			registro.Estado = this.GetDbString(reader, "Estado");
			registro.AlumnoHombres = this.GetDbInt(reader, "AlumnoHombres");
			registro.AlumnoMujeres = this.GetDbInt(reader, "AlumnoMujeres");
			registro.Docentes = this.GetDbInt(reader, "Docentes");
			registro.UbigeoInei = this.GetDbString(reader, "UbigeoInei");
			registro.UbigeoReniec = this.GetDbString(reader, "UbigeoReniec");
            //registro.totalPagina = this.GetDbInt(reader, "totalPagina");
        }

		#endregion
	}
}
